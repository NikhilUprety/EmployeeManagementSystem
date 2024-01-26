using EmployeeManagementSystem.DataContext;
using EmployeeManagementSystem.Models.Domain;
using EmployeeManagementSystem.Repository.IRepository;
using System.Linq.Expressions;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class EmployeeRepository : Repository<EmployeeModel>, IEmployeeRepository
    {
        private EmployeeDbContext _Db;
        public EmployeeRepository(EmployeeDbContext db) : base(db)
        {

            _Db = db;

        }
        public void save()
        {
            _Db.SaveChanges();
        }

        public void update(EmployeeModel obj)
        {
            _Db.Update(obj);
        }
    }

}
