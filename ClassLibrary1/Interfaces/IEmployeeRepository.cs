using Project_DAL.Models;

namespace Project_BLL.Interfaces
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        IEnumerable<Employee> Search(string word);
       
    }
}
