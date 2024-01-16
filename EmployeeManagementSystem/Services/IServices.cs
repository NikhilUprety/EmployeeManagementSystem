namespace EmployeeManagementSystem.Services
{
    public interface IServices<T> where T : class
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
    }
}
