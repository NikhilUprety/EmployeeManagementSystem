using EmployeeManagementSystem.Models.Domain;

namespace EmployeeManagementSystem.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<EmployeeModel>
    {
        object Employee { get; set; }
        object Employetable { get; set; }
        void update(EmployeeModel obj);
        void save();

    }
} 
