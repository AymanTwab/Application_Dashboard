using AutoMapper;
using Project_DAL.Models;
using Project_PL.Models;

namespace Project_PL.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, CreateAndUpdateEmployeeViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeDetailsViewModel>().ReverseMap();
        }
    }
}
