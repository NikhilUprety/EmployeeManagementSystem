using EmployeeManagementSystem.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.DataContext
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
            
        }

        public DbSet<EmployeeModel>? EmployeeTable { get;set; } 
       }
   

}
