namespace Project_DAL.Models
{
    public class Employee: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public double Salary { get; set; }
        public DateTime HiringDate { get; set; } = DateTime.Now;
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public string ImageUrl { get; set; }

    }
}
