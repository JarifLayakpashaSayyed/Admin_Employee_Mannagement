using Employee_Mannagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Mannagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<EmployeeModel> Employees_Management { get; set; }
    }
}
