//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cotizador.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class mvcCotizacionDet
    {
        public int id { get; set; }
        public int idCotEnc { get; set; }
        public int InvtId { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double MontoTotal { get; set; }
        public int status { get; set; }
    
        public virtual mvcCotizacionEnc mvcCotizacionEnc { get; set; }
    }
}
