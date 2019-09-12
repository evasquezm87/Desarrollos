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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using (IDEAAPPEntities db = new IDEAAPPEntities())
            {
                lst = (from d in db.mvcUsuario
                       where d.status == 1
                       orderby d.id
                       select new UserTableViewModel
                       {
                           Id = d.id,
                           Email = d.eMail
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
        public ActionResult Add(UserViewModel model)
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
                mvcUsuario oUser = new mvcUsuario();
                oUser.status = 1;
                oUser.eMail = model.Email;
                oUser.password = model.Password;

                //agregarlo a la lista y guardarlo en la bd
                db.mvcUsuario.Add(oUser);
                db.SaveChanges();
            }

            //si todo es correcto regresarlo a la vista de todos los usaurios
            return Redirect(Url.Content("~/User/"));

        }

        public ActionResult Edit(int Id)
        {
            //Es para capturar los datos del usuario

            EditUserViewModel model = new EditUserViewModel();

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
                var oUser = db.mvcUsuario.Find(Id);
                model.Email = oUser.eMail.Trim();//Obligatorio el trim en los string para las validaciones annotations
                model.Id = oUser.id;
                model.EmpleadoSL = oUser.idEmpleado;

            }


            //Enviar listado de empleados en el viewbag para el dropdownlist
            List<EmpleadosSLViewModel> lstEmpleados = null;
            using (IDEAAPPEntities db = new IDEAAPPEntities())
            {
                lstEmpleados = (from d in db.mvcEmpleadosSL
                                select new EmpleadosSLViewModel
                                {
                                    Id = d.id,
                                    empId = d.EmpID,
                                    Nombre = d.Name
                                }).ToList();
            }

            List<SelectListItem> items = lstEmpleados.ConvertAll(d =>

            {
                return new SelectListItem()
                {
                    Text = d.empId.ToString() + " - " + d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;
            //Termina de llenar los datos para el dropdownlist

            //recibe el modelo con los datos para que lo llene
            return View(model);
        }

        //Este metodo va a recibir el modelo
        [HttpPost]//Para que sea en el evento POST, si no se pone nada toma el Get
        public ActionResult Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new IDEAAPPEntities())
            {
                var oUser = db.mvcUsuario.Find(model.Id);

                //Agregar lo editado
                oUser.eMail = model.Email.Trim();
                oUser.idEmpleado = model.EmpleadoSL;
                

                //Es para actualizar el password, como no es obligatorio se añade la condicion
                //El trim debe hacerse solo despues de verificar que no sea null
                if (model.Password != null && model.Password.Trim() != "")
                {
                    oUser.password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }


            //si todo es correcto regresarlo a la vista de todos los usaurios
            return Redirect(Url.Content("~/User/"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new IDEAAPPEntities())
            {
                var oUser = db.mvcUsuario.Find(Id);
                oUser.status = 3; //eliminaremos

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Content("1");
        }
    }
}