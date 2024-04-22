using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_BLL.Interfaces;
using Project_DAL.Models;
using Project_PL.Helper;
using Project_PL.Models;

namespace Project_PL.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index(string SearchValue="")
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(SearchValue))
                employees =_unitOfWork.EmployeeRepository.GetAll();
            else
                employees = _unitOfWork.EmployeeRepository.Search(SearchValue);
            var employeeDetailsViewModel = _mapper.Map<IEnumerable<EmployeeDetailsViewModel>>(employees);
            foreach (var item in employeeDetailsViewModel)
            {
                item.DepartmentName = _unitOfWork.DepartmentRepository.GetById(item.DepartmentId).Name;
            }
            return View(employeeDetailsViewModel);
        }

        public IActionResult Create()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var departmentItems = departments.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
            //ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            var createAndUpdateEmployeeViewModel = new CreateAndUpdateEmployeeViewModel()
            {
                Departments = departmentItems
            };
            return View(createAndUpdateEmployeeViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateAndUpdateEmployeeViewModel createAndUpdateEmployeeViewModel)
        {
            //ModelState["Department"].ValidationState = ModelValidationState.Valid;
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(createAndUpdateEmployeeViewModel);
                employee.ImageUrl = DocumentSettings.UploadFile(createAndUpdateEmployeeViewModel.Image, "Images");
                _unitOfWork.EmployeeRepository.Add(employee);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            //ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var departmentItems = departments.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
            //ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            createAndUpdateEmployeeViewModel = new CreateAndUpdateEmployeeViewModel()
            {
                Departments = departmentItems
            };
            return View(createAndUpdateEmployeeViewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee is null)
                return NotFound();
            DocumentSettings.DeleteFile(employee.ImageUrl);
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id is null)
                return BadRequest();
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee is null)
                return NotFound();
            var employeeViewModel = _mapper.Map<CreateAndUpdateEmployeeViewModel>(employee);
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var departmentItems = departments.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
            employeeViewModel.Departments = departmentItems;
            return View(employeeViewModel);
        }

        [HttpPost]
        public IActionResult Update(CreateAndUpdateEmployeeViewModel employeeViewModel) 
        {
            if(employeeViewModel is null)
                return NotFound();
            //ModelState["Department"].ValidationState = ModelValidationState.Valid;
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(employeeViewModel);
                _unitOfWork.EmployeeRepository.Update(employee);
                _unitOfWork.Complete();
                return RedirectToAction("Details", new {id = employee.Id});
            }
            return View(employeeViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if(employee is null)
                return NotFound();
            var employeeViewModel = _mapper.Map<EmployeeDetailsViewModel>(employee);
            employeeViewModel.DepartmentName = _unitOfWork.DepartmentRepository.GetById(employee.DepartmentId).Name;
            return View(employeeViewModel);
        }

    }
}
