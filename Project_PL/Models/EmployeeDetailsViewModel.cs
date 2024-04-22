namespace Project_PL.Models
{
    public class EmployeeDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public double Salary { get; set; }
        public DateTime HiringDate { get; set; } = DateTime.Now;
        public int DepartmentId { get; set; }
        public string ImageUrl { get; set; }
        public string DepartmentName { get; set; }
    }
}
