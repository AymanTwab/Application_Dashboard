using Project_BLL.Interfaces;
using Project_DAL.Context;
using Project_DAL.Models;

namespace Project_BLL.Repositories
{
    public class EmployeeRepository :GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CompanyDbContext _context;
        public EmployeeRepository(CompanyDbContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee> Search(string word)
        {
            var result = _context.Employees.Where(employee => 
                        employee.Name.Trim().ToLower().Contains(word.Trim().ToLower()));
            return result;
        }
    }
}
