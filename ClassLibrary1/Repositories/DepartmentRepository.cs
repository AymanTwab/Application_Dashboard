using Project_BLL.Interfaces;
using Project_DAL.Context;
using Project_DAL.Models;

namespace Project_BLL.Repositories
{
    public class DepartmentRepository:GenericRepository<Department>, IDepartmentRepository
    {
        private readonly CompanyDbContext _context;
        public DepartmentRepository(CompanyDbContext context):base(context)
        {
            _context = context;
        }

    }
}
