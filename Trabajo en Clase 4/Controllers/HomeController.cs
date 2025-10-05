using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OutputCaching;
using System.Diagnostics;
using Trabajo_en_Clase_4.Controllers.ActionFilters;
using Trabajo_en_Clase_4.Models;


namespace MvcApplication1.Controllers
{
    [LogActionFilter]
    public class HomeController : Controller
    {
        [Route("")] //Home
        [Route("Indice")] // Home/Index
        [Route("/")] //""
        public IActionResult Index()
        {
            var estudiante = new Estudiante(1, "Juan Pérez", 95);
            return View(estudiante); //default ViewData.Model
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult About()
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

        [ActionName("Sumar")]
        public IActionResult Sum()
        {
            int num1 = Convert.ToInt32(HttpContext.Request.Form["tx1"].ToString());
            int num2 = Convert.ToInt32(HttpContext.Request.Form["tx2"].ToString());
            ViewBag.Result = (num1 + num2).ToString();
            return View("ActionName");
        }
        public string SumTemp()
        {
            int num1 = Convert.ToInt32(HttpContext.Request.Form["tx1"].ToString());
            int num2 = Convert.ToInt32(HttpContext.Request.Form["tx2"].ToString());
            return (num1 + num2).ToString();
        }

        [HttpPost]
        public IActionResult add3()
        {
            int num1 = Convert.ToInt32(HttpContext.Request.Form["tx1"].ToString());
            int num2 = Convert.ToInt32(HttpContext.Request.Form["tx2"].ToString());
            ViewBag.Result = (num1 + num2).ToString();
            return View("ActionVerbs");
        }
    }

}
