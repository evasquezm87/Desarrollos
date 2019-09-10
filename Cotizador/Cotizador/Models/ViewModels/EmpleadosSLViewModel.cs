using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cotizador.Models.ViewModels
{
    
        /*Clase modelo para agregar registros*/
        public class EmpleadosSLViewModel
        {

            [Required]
            [Display(Name = "ID")]
            public int Id { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "El {0} debe tener almenos {1} caracteres", MinimumLength = 1)]
            [Display(Name = "ID Empleado")]
            public string empId { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "El {0} debe tener almenos {1} caracteres", MinimumLength = 1)]
            [Display(Name = "Nombre")]
            public string Nombre { get; set; }
        
        }

        /*Clase modelo para editar registros
         Se utiliza esto en lugar del default cuando en ocasiones no se va a eliminar todo*/
        public class EditEmpleadosSLViewModel
    {
            public int Id { get; set; }//Para saber el ID que esta afectando

            [Required]
            [StringLength(30, ErrorMessage = "El {0} debe tener almenos {1} caracteres", MinimumLength = 1)]
            [Display(Name = "ID Empleado")]
            public string empId { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "El {0} debe tener almenos {1} caracteres", MinimumLength = 1)]
            [Display(Name = "Nombre")]
            public string Nombre { get; set; }
        }
 
}