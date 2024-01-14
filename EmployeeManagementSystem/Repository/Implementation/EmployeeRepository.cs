using EmployeeManagementSystem.Models.Domain;
using EmployeeManagementSystem.Repository.IRepository;
using System.Linq.Expressions;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void Add(EmployeeModel entity)
        {
            throw new NotImplementedException();
        }

        public EmployeeModel Get(Expression<Func<EmployeeModel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(EmployeeModel entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<EmployeeModel> entity)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void update(EmployeeModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
