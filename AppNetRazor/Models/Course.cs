using System.ComponentModel.DataAnnotations;

namespace AppNetRazor.Models
{
    public class Course // son las propiedades que a su vez seran los campos de la base de datos que seran creados en la tabla en una migracion mediante nuget
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre Del Curso")]
        public string CourseName { get; set; }
        [Display(Name = "Sesiones")]
        public int QuantitySessions { get; set; }
        [Display(Name = "Precio")]
        public int Price { get; set; }
        [Display(Name = "Registrado El")]
        public DateTime RegisterDate {get; set; }
    }
}
