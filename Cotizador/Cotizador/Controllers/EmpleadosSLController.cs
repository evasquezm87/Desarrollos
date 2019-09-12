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
    public class EmpleadosSLController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<EmpleadosSLTableViewModel> lst = null;
            using (IDEAAPPEntities db = new IDEAAPPEntities())
            {
                lst = (from d in db.mvcEmpleadosSL
                       where d.status == 1
                       orderby d.id
                       select new EmpleadosSLTableViewModel
                       {
                           Id = d.id,
                           EmpId = d.EmpID,
                           Name = d.Name
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
        public ActionResult Add(EmpleadosSLViewModel model)
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
                mvcEmpleadosSL oEmpleado = new mvcEmpleadosSL();
                oEmpleado.status = 1;
                oEmpleado.EmpID = model.empId;
                oEmpleado.Name = model.Nombre;

                //agregarlo a la lista y guardarlo en la bd
                db.mvcEmpleadosSL.Add(oEmpleado);
                db.SaveChanges();
            }

            //si todo es correcto regresarlo a la vista de todos los usaurios
            return Redirect(Url.Content("~/EmpleadosSL/"));

        }

        public ActionResult Edit(int Id)
        {
            
            EditEmpleadosSLViewModel model = new EditEmpleadosSLViewModel();

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
                var oEmpleado = db.mvcEmpleadosSL.Find(Id);
                model.empId = oEmpleado.EmpID.Trim();//Obligatorio el trim en los string para las validaciones annotations
                model.Nombre = oEmpleado.Name;
                model.Id = oEmpleado.id;

            }

            //recibe el modelo con los datos para que lo llene
            return View(model);
        }



        //Este metodo va a recibir el modelo
        [HttpPost]//Para que sea en el evento POST, si no se pone nada toma el Get
        public ActionResult Edit(EditEmpleadosSLViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new IDEAAPPEntities())
            {
                var oEmpleado = db.mvcEmpleadosSL.Find(model.Id);

                //Agregar lo editado
                oEmpleado.EmpID = model.empId.Trim();
                oEmpleado.Name = model.Nombre.Trim();
                

                db.Entry(oEmpleado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }


            //si todo es correcto regresarlo a la vista de todos los usaurios
            return Redirect(Url.Content("~/EmpleadosSL/"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new IDEAAPPEntities())
            {
                var oEmpleado = db.mvcEmpleadosSL.Find(Id);
                oEmpleado.status = 3; //eliminaremos

                db.Entry(oEmpleado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Content("1");
        }
    }
}