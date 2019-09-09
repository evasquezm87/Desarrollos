using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CotizadorMVC.Models.ViewModels
{
    /*Clase modelo para agregar registros*/
    public class UserViewModel
    {
        
        [Required]
        [EmailAddress]
        [StringLength(30,ErrorMessage ="El {0} debe tener almenos {1} caracteres", MinimumLength =1)]
        [Display(Name ="Correo Electrónico")]
        public  string Email { get; set; }

        [Required]
        [DataType( DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        //Ya que ocupamos validar que la contraseña sea correcta se añade esta propiedad.
        //Este campo no esta en la tabla y no se guarda, solo es para validar
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password",ErrorMessage ="Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; }
    }

    /*Clase modelo para editar registros
     Se utiliza esto en lugar del default cuando en ocasiones no se va a eliminar todo*/
    public class EditUserViewModel
    {
        public int Id { get; set; }//Para saber el ID que esta afectando
        
        [Required]
        [EmailAddress]
        [StringLength(30, ErrorMessage = "El {0} debe tener almenos {1} caracteres", MinimumLength = 1)]
        
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
                
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        //Ya que ocupamos validar que la contraseña sea correcta se añade esta propiedad.
        //Este campo no esta en la tabla y no se guarda, solo es para validar
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; }
    }
}