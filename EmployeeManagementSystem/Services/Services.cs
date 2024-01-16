using EmployeeManagementSystem.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Services
{
    public class Services<T> : IServices<T> where T: class
    {
        public EmployeeDbContext _dbcontext;
        internal DbSet<T> db;

        //DbSet<Student> db;

        public Services(EmployeeDbContext dbcontext) {
            _dbcontext = dbcontext;

            this.db = _dbcontext.Set<T>();
            // db = dbcontext.Set<Student>();
            //dbcontext.Table
        }
        public void Add(T entity)
        {
            db.Add(entity);

        }
        IEnumerable<T> GetAll()
        {
            IQueryable<T> query = db;
            return query.ToList();
        }
    }
}
