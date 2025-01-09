using curd.webApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace curd.webApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        } 
        public DbSet<Employee> Employees { get; set; }
    }
    
    
}
