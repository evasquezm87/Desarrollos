using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cotizador.Models;
using Cotizador.Models.TableViewModels;
using Cotizador.Models.ViewModels;

namespace Cotizador.Controllers
{
    public class CotizacionDetController : Controller
    {
        // GET: CotizacionDet        
        public ActionResult Index(int id)
        {
            List<CotizacionDetTableViewModel> lst = null;
            using (IDEAAPPEntities db = new IDEAAPPEntities())
            {
                lst = (from d in db.mvcCotizacionDet
                       where d.idCotEnc == id 
                       orderby d.id
                       select new CotizacionDetTableViewModel
                       {
                           id = d.id,
                           idCotEnc = d.idCotEnc,
                           InvtId = d.InvtId,
                           Cantidad = d.Cantidad,
                           PrecioUnitario = d.PrecioUnitario,
                           MontoTotal = d.MontoTotal,
                           status = d.status
                       }).ToList();                
            }



            //Regresa la vista y le envia un list
            ViewBag.idCotEnc = id;
            return View(lst);
        }


        [HttpGet] //Obligar para que solo entre por protocolo Get
        public ActionResult Add()
        {
            return View();
        }



        [HttpPost] //Obligar para que solo entre por protocolo post
        public ActionResult Add(CotizacionDetViewModel model)
        {
            //Validar los data annotation, usando un objeto especial
            //valida, si hay error regresa a la vista, pero deja los valores que
            //se habian capturado, excepto las contraseñas
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Obtener el id de la cotizacion
            //Revisar recibirlo automaticamente
            string idCotEnc =  RouteData.Values["id"] + Request.Url.Query;

            //si no hubo error guardar en la BD}
            using (var db = new IDEAAPPEntities())
            {
                //crear el objeto cotizacion detalle
                mvcCotizacionDet oCotizacionDet = new mvcCotizacionDet();
                //oCotizacionDet.id = model.id
                oCotizacionDet.status = 1;
                oCotizacionDet.idCotEnc = Convert.ToInt32(idCotEnc);
                oCotizacionDet.InvtId = model.InvtId;
                oCotizacionDet.Cantidad = model.Cantidad;
                oCotizacionDet.PrecioUnitario = model.PrecioUnitario;
                oCotizacionDet.MontoTotal = model.MontoTotal;

                //agregarlo a la lista y guardarlo en la bd
                db.mvcCotizacionDet.Add(oCotizacionDet);
                db.SaveChanges();
            }

            //si todo es correcto regresarlo a la vista principal
            return Redirect(Url.Content("~/CotizacionDet/Index/" + Convert.ToInt32(idCotEnc)));

        }


        public ActionResult Edit(int Id)
        {
            //Es para capturar los datos del detalle

            EditCotizacionEncViewModel model = new EditCotizacionEncViewModel();

            /*var.- se crea el tipo de objeto que se le asigna sin importar el tipo
             * var numero = new int; //la variable numero al inicio no tiene definido el tipo, 
             *      pero despues de la asignacion se convierte a entero
             *var oUsuario = new Usuario(); es igual a 
             * Usuario oUsuario = new Usuario();
             * Es lo recomendado por Microsoft      
             */
            using (var db = new IDEAAPPEntities())
            {
                //Trae el objeto que viene el el listado, se manda parametro id
                //ya no es necesario validar si el parametro enviado es correcto
                var oCotizacion = db.mvcCotizacionEnc.Find(Id);
                model.NoCotizacion = oCotizacion.NoCotizacion.Trim();//Obligatorio el trim en los string para las validaciones annotations
                model.Descripcion = oCotizacion.Descripcion.Trim();
                model.CustId = oCotizacion.CustId;
                model.Monto = oCotizacion.Monto;

            }


            //recibe el modelo con los datos para que lo llene
            return View(model);
        }

        //Este metodo va a recibir el modelo
        [HttpPost]//Para que sea en el evento POST, si no se pone nada toma el Get
        public ActionResult Edit(EditCotizacionEncViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new IDEAAPPEntities())
            {
                var oCotizacion = db.mvcCotizacionEnc.Find(model.id);

                //Agregar lo editado
                oCotizacion.Descripcion = model.Descripcion;
                oCotizacion.CustId = model.CustId;
                oCotizacion.Monto = model.Monto;


                db.Entry(oCotizacion).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }


            //si todo es correcto regresarlo a la vista de todos los usaurios
            return Redirect(Url.Content("~/CotizacionEnc/"));
        }


    }
}