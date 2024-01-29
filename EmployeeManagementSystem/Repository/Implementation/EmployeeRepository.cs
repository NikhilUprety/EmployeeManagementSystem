using EmployeeManagementSystem.DataContext;
using EmployeeManagementSystem.Models.Domain;
using EmployeeManagementSystem.Repository.IRepository;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class EmployeeRepository : Repository<EmployeeModel>, IEmployeeRepository
    {
        private IWebHostEnvironment _environment;
        private EmployeeDbContext _Db;
        public EmployeeRepository(EmployeeDbContext db) : base(db)
        {

            _Db = db;

        }
        public void save()
        {
            _Db.SaveChanges();
        }
        public string? SaveFileAndReturnName(string path, IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    string uniqueName = Guid.NewGuid().ToString() + file.FileName;
                    string serverLocation = Path.Combine(_environment.WebRootPath, Path.Combine(path, uniqueName));
                    file.CopyTo(new FileStream(serverLocation, FileMode.Create));
                    return uniqueName;
                }
                else
                {
                    return "maledefault.png";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception saving file: {ex.Message}");
                return "maledefault.png";
            }
        }
        public void update(EmployeeModel obj)
        {
            _Db.Update(obj);
        }
    }

}
