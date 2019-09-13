using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cotizador.Models.TableViewModels
{
    public class CotizacionDetTableViewModel
    {
        public int id { get; set; }
        public int idCotEnc { get; set; }
        public int InvtId { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double MontoTotal { get; set; }
        public int status { get; set; }
    }
}