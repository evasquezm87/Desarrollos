using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cotizador.Models.ViewModels
{
    public class CotizacionDetViewModel
    {

        [Display(Name = "Cotizacion")]
        public int idCotEnc { get; set; }

        [Required]
        [Display(Name = "Id Articulo")]
        public int InvtId { get; set; }

        [Required]
        [Display(Name = "Cantidad")]        
        public double Cantidad{ get; set; }

        [Required]
        [Display(Name = "PrecioUnitario")]
        public double PrecioUnitario { get; set; }

        [Required]
        [Display(Name = "MontoTotal")]
        public double MontoTotal { get; set; }

    }

    /*Clase modelo para editar registros
     Se utiliza esto en lugar del default cuando en ocasiones no se va a eliminar todo*/
    public class EditCotizacionDetViewModel
    {
        public int Id { get; set; }//Para saber el ID que esta afectando

        [Required]
        [StringLength(30, ErrorMessage = "El {0} debe tener almenos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Id Articulo")]
        public string InvtId { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public double Cantidad { get; set; }

        [Required]
        [Display(Name = "PrecioUnitario")]
        public double PrecioUnitario { get; set; }

        [Required]
        [Display(Name = "MontoTotal")]
        public double MontoTotal { get; set; }



    }

}