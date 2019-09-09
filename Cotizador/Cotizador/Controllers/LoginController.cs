using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cotizador.Models;

namespace Cotizador.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (IDEAAPPEntities db = new IDEAAPPEntities())
                {
                    var lst = from d in db.mvcUsuario
                              where d.eMail == user && d.password == password && d.status == 1
                              select d;

                    if ((lst.Count() > 0))
                    {
                        mvcUsuario oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario Invalido");
                    }
                }


            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error. " + ex.Message);
            }
        }
    }
}