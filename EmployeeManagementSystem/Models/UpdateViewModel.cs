namespace EmployeeManagementSystem.Models
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public IFormFile? photo { get; set; }
    }
}
