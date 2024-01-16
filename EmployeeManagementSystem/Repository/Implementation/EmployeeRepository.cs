using EmployeeManagementSystem.DataContext;
using EmployeeManagementSystem.Models.Domain;
using EmployeeManagementSystem.Repository.IRepository;
using System.Linq.Expressions;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class EmployeeRepository : Repository<EmployeeModel>, IEmployeeRepository
    {
        private  EmployeeDbContext _employeeDbContext;
        public EmployeeRepository(EmployeeDbContext employeeDbContext) : base(employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }


        public void save()
        {
            _employeeDbContext.SaveChanges();
        }

        public void update(EmployeeModel obj)
        {
            _employeeDbContext.EmployeeTable.Update(obj);
        }
        
    }
}
