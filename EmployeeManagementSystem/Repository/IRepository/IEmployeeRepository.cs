using EmployeeManagementSystem.Models.Domain;
using System.Linq.Expressions;

namespace EmployeeManagementSystem.Repository.IRepository
{
    public class IEmployeeRepository : IRepository<EmployeeModel>
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
    }
}
 