using AppNetRazor.Data;
using AppNetRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppNetRazor.Pages.Courses
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext _context; //importamos el appdbcontext para acceder a la db
        public AddModel(ApplicationDbContext context) // creamos el constructor para poder usar el context
        {
            _context = context;
        }



        [BindProperty] // propiedad de vinculacion
        public Course _courseform { get; set; } //vincular propiedad con los datos del formulario



        [TempData]
        public string Msg { get; set; }



        public async Task<IActionResult> OnPost() // Metodo para agregar un nuevo curso
        {
            if (!ModelState.IsValid) { // si algun campo del formulario no es valido recarga la pagina del formulario
                return RedirectToPage();
            }

            _courseform.RegisterDate = DateTime.Now; // asignamos la fecha actual del sistema a la variable de fecha de registro
            _context.Add(_courseform); // enviamos a la base de datos la propiedad con la informacion recogida del formulario
            await _context.SaveChangesAsync(); // guardamos los cambios de manera asincrona
            Msg = "Curso Creado Correctamente";
            return RedirectToPage("Index");


        }
    }
}
