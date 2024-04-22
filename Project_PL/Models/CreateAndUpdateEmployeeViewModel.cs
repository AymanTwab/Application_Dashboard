using Microsoft.AspNetCore.Mvc.Rendering;
using Project_DAL.Models;

namespace Project_PL.Models
{
    public class CreateAndUpdateEmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public double Salary { get; set; }
        public DateTime HiringDate { get; set; } = DateTime.Now;
        public IFormFile Image {  get; set; }
        public string? ImageUrl { get; set; }
        public int DepartmentId { get; set; }
        public IEnumerable<SelectListItem>? Departments { get; set; }
    }
}
