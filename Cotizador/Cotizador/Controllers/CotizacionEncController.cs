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
    public class CotizacionEncController : Controller
    {
        // GET: CotizacionEnc
        //Mostrar el listado de todas las cotizaciones
        public ActionResult Index()
        {

            List<CotizacionEncTableViewModel> lst = null;
            using (IDEAAPPEntities db = new IDEAAPPEntities())
            {
                lst = (from d in db.mvcCotizacionEnc
                       where d.status == 1
                       orderby d.id
                       select new CotizacionEncTableViewModel
                       {
                           id = d.id,
                           NoCotizacion = d.NoCotizacion,
                           CustId = d.CustId,
                           Descripcion = d.Descripcion,
                           Monto = d.Monto
                       }).ToList();
            }



            //Regresa la vista y le envia un list
            return View(lst);
        }



        [HttpGet] //Obligar para que solo entre por protocolo Get
        public ActionResult Add()
        {
            return View();
        }



        [HttpPost] //Obligar para que solo entre por protocolo post
        public ActionResult Add(CotizacionEncViewModel model)
        {
            //Validar los data annotation, usando un objeto especial
            //valida, si hay error regresa a la vista, pero deja los valores que
            //se habian capturado, excepto las contraseñas
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //si no hubo error guardar en la BD}
            using (var db = new IDEAAPPEntities())
            {
                //crear el objeto user
                mvcCotizacionEnc oCotizacionEnc= new mvcCotizacionEnc();
                oCotizacionEnc.status = 1;
                oCotizacionEnc.NoCotizacion = model.NoCotizacion;
                oCotizacionEnc.CustId = model.CustId;
                oCotizacionEnc.Descripcion = model.Descripcion;
                oCotizacionEnc.Monto = model.Monto;
                

                //agregarlo a la lista y guardarlo en la bd
                db.mvcCotizacionEnc.Add(oCotizacionEnc);
                db.SaveChanges();
            }

            //si todo es correcto regresarlo a la vista de todos los usaurios
            return Redirect(Url.Content("~/CotizacionEnc/"));

        }


        public ActionResult Edit(int Id)
        {
            //Es para capturar los datos del usuario

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