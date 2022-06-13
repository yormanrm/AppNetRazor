using AppNetRazor.Data;
using AppNetRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppNetRazor.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context; //importamos el appdbcontext para acceder a la db

        public IndexModel(ApplicationDbContext context) // creamos el constructor para poder usar el context
        {
            _context = context;
        }

        public IEnumerable<Course> _courses { get; set; } //instanciamos el modelo de Cursos en _courses para usarlo en la pagina html



        [TempData]
        public string Msg { get; set; }


        public async Task OnGet() // peticion get para traer los cursos disponibles en la db
        {
            _courses = await _context.Courses.ToListAsync(); //convierte en lista la informacion proveniente de la consulta get
        }


        public async Task<IActionResult> OnPostDelete(int id) // Metodo para eliminar un nuevo curso
        {
            var CourseDB = await _context.Courses.FindAsync(id); //igualamos nuestra propiedad de vinculacion con los datos del formulario los cuales contienen la informacion tanto actual como la nueva del curso
            if (CourseDB == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(CourseDB); // elimina el curso
            await _context.SaveChangesAsync(); // guardamos los cambios de manera asincrona
            Msg = "Curso Eliminado Correctamente";
            return RedirectToPage("Index");

        }

    }
}
