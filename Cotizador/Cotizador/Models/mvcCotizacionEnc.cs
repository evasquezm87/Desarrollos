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
    
    public partial class mvcCotizacionEnc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mvcCotizacionEnc()
        {
            this.mvcCotizacionDet = new HashSet<mvcCotizacionDet>();
        }
    
        public int id { get; set; }
        public string NoCotizacion { get; set; }
        public string Descripcion { get; set; }
        public int CustId { get; set; }
        public double Monto { get; set; }
        public int status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mvcCotizacionDet> mvcCotizacionDet { get; set; }
    }
}
