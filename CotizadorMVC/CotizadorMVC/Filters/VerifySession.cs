using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CotizadorMVC.Models;
using CotizadorMVC.Controllers;

namespace CotizadorMVC.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        //Sobrecargar metodo
        //Sustitiur metodo del padre, va a realizar lo que le indiquemos aqui y luego lo que hace el metodo padre
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Verificar si el usuario existe
            var oUser = (mvcUsuario)HttpContext.Current.Session["User"];

            if(oUser == null)
            {
                //Filtro para no ciclar la aplicacion
                //Solo cuando sea desde access controller entre la condicion
                if(filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else
            {
                //Si ya tiene sesion que no pueda vover a entrar al login
                if(filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            //Esto es lo que hace el padre, lo que coloquemos antes de aqui es lo que realizara
            base.OnActionExecuting(filterContext);
        }
    }
}