using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    

    public class SchoolContext : IdentityDbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        { 

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Category> Categories { get; set; }
        
    }

}
