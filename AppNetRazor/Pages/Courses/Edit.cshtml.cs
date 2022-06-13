using AppNetRazor.Data;
using AppNetRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppNetRazor.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context; //importamos el appdbcontext para acceder a la db
        public EditModel(ApplicationDbContext context) // creamos el constructor para poder usar el context
        {
            _context = context;
        }



        [BindProperty] // propiedad de vinculacion
        public Course _courseform { get; set; } //vincular propiedad con los datos del formulario



        [TempData]
        public string Msg { get; set; }



        public async Task OnGet(int id)
        {
            _courseform = await _context.Courses.FindAsync(id);
        }


        public async Task<IActionResult> OnPost() // Metodo para agregar un nuevo curso
        {
            if (ModelState.IsValid)
            { // si el modelo es correcto obtemos el curso de la db
                var CourseDB = await _context.Courses.FindAsync(_courseform.Id); //igualamos nuestra propiedad de vinculacion con los datos del formulario los cuales contienen la informacion tanto actual como la nueva del curso
                CourseDB.CourseName = _courseform.CourseName;
                CourseDB.QuantitySessions = _courseform.QuantitySessions;
                CourseDB.Price = _courseform.Price;

                await _context.SaveChangesAsync(); // guardamos los cambios de manera asincrona
                Msg = "Curso Modificado Correctamente";
                return RedirectToPage("Index");
            }

            return RedirectToPage();

        }

    }
}
