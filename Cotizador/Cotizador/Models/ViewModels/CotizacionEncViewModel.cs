using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cotizador.Models.ViewModels
{
        
    public class CotizacionEncViewModel
    {
        [Required]        
        //[StringLength(10, ErrorMessage = "El {0} debe tener almenos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Número Cotización")]
        public string NoCotizacion { get; set; }

        [Required]
        //[StringLength(100, ErrorMessage = "El {0} debe tener almenos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public int CustId { get; set; }

        [Required]
        [Display(Name = "Monto")]
        public double Monto { get; set; }
        

        

    }

    /*View Model para evento de Nuevo*/
    public class EditCotizacionEncViewModel
    {
        public int id { get; set; }//Para saber el ID que esta afectando

        [Required]
        [StringLength(10, ErrorMessage = "El {0} debe tener almenos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Número Cotización")]
        public string NoCotizacion { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener almenos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public int CustId { get; set; }

        [Required]
        [Display(Name = "Monto")]
        public double Monto { get; set; }
        



    }
}