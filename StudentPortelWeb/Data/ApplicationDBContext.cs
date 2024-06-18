using Microsoft.EntityFrameworkCore;
using StudentPortelWeb.Models.Entities;

namespace StudentPortelWeb.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
