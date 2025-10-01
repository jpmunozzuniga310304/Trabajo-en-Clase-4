using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OutputCaching;
using System.Diagnostics;
using Trabajo_en_Clase_4.Models;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var estudiante = new Estudiante(1, "Juan Pérez", 95);
        return View(estudiante); //default ViewData.Model
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [OutputCache(Duration = 10)]
    public string IndexII()
    {
        return DateTime.Now.ToString("T"); //muestra el mismo resultado durante 10 segundos
    }
    public IActionResult ActionName()
    {
        return View();
    }

    public IActionResult NonAction()
    {
        return View();
    }
    public IActionResult ActionVerbs()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Suma()
    {
        try
        {
            int num1 = Convert.ToInt32(HttpContext.Request.Form["n1"].ToString());
            int num2 = Convert.ToInt32(HttpContext.Request.Form["n2"].ToString());
            ViewBag.Result = (num1 + num2).ToString();
        }
        catch (Exception)
        {
            ViewBag.Result = "Datos erroneos ingresados.";
        }
        return View("bCalc");
    }


    [NonAction]
    public string SumTemp()
    {
        int num1 = Convert.ToInt32(HttpContext.Request.Form["n1"].ToString());
        int num2 = Convert.ToInt32(HttpContext.Request.Form["n2"].ToString());
        return (num1 + num2).ToString();
    }

    [HttpPost]
    public IActionResult Suma3()
    {
        int num1 = Convert.ToInt32(HttpContext.Request.Form["n1"].ToString());
        int num2 = Convert.ToInt32(HttpContext.Request.Form["n2"].ToString());
        ViewBag.Result = (num1 + num2).ToString();
        return View("bCalc");
    }
}

namespace Trabajo_en_Clase_4.ActionFilters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", filterContext.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData);
        }

        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}",
           methodName, controllerName, actionName);
            Debug.WriteLine(message, "Action Filter Log");
        }
       

    }
}

