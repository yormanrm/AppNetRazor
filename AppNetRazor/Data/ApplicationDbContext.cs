using AppNetRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace AppNetRazor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){} // mandar a opciones de ProgramCS

        //Database Models
        public DbSet<Course> Courses { get; set; } // importar el modelo con el que trabajara
        public object Course { get; internal set; }
    }
}


// add-migration v1
// update-database