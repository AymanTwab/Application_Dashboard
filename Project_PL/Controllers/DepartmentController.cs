using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_BLL.Interfaces;
using Project_DAL.Models;

namespace Project_PL.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(
            IUnitOfWork unitOfWork,
            ILogger<DepartmentController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public IActionResult Create(Department deprtment)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DepartmentRepository.Add(deprtment);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(deprtment);
        }
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            var department = _unitOfWork.DepartmentRepository.GetById(id);

            if (department is null)
                return NotFound();
            
            _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int? id)
        {
            if (id is null)
                return BadRequest();

            var department = _unitOfWork.DepartmentRepository.GetById(id);

            if (department is null)
                return NotFound();

            return View(department);
        }
        [HttpPost]
        public IActionResult Update(Department department)
        {
            if (department is null)
                return RedirectToAction("Index");
            
            _unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.Complete();
            return RedirectToAction("Details", new {id = department.Id});
        }

        public IActionResult Details(int? id)
        {
            try
            {
                if (id is null)
                    return BadRequest();
                
                var department = _unitOfWork.DepartmentRepository.GetById(id);

                if (department is null)
                    return NotFound();  
                
                return View(department);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error","Home");
            }

        }
    }
}
