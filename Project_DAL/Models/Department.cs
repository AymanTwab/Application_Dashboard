using System.ComponentModel.DataAnnotations;

namespace Project_DAL.Models
{
    public class Department:BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreationDate {  get; set; } = DateTime.Now;
    }
}
