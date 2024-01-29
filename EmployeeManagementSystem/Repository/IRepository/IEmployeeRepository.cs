using EmployeeManagementSystem.Models.Domain;

namespace EmployeeManagementSystem.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<EmployeeModel>
    {
      
        void update(EmployeeModel obj);
        void save();
        public string? SaveFileAndReturnName(string path, IFormFile formFile);


    }
} 
