using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicio;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
        }

        public IActionResult Index()
        {
            //ViewBag.Nombre = "Julio Sierra";
            //ViewBag.Edad = "21";
            /*var persona = new Persona()
            {
                Nombre = "Julio",
                Edad = 21
            };*/

            var proyectos= repositorioProyectos.ObtenerProyecto().Take(3).ToList();
            var modelo= new HomeIndexViewModel(){ Proyectos = proyectos};
            return View(modelo);
        }

        

       public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyecto();
            return View(proyectos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}