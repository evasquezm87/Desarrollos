using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cotizador.Models.TableViewModels
{
    public class CotizacionEncTableViewModel
    {
        public int id { get; set; }
        public string NoCotizacion { get; set; }
        public string Descripcion { get; set; }
        public int CustId { get; set; }
        public double Monto { get; set; }
        //public int status { get; set; }
    }
}