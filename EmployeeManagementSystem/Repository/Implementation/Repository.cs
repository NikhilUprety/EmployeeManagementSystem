﻿using EmployeeManagementSystem.DataContext;
using EmployeeManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private DbSet<T> dbset;
        public Repository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
            this.dbset = _employeeDbContext.Set<T>();
            //_employeeDbContext==dbset
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {

            return dbset.AsEnumerable();
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
           dbset.RemoveRange(entity);
        }
        public IEnumerable<T> GetAllData(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbset;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.ToList();
        }
    }
}
