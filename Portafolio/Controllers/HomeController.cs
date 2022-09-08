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
        private readonly IServicioEmailSendGrid servicioEmailSendGrid;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos, IServicioEmailSendGrid servicioEmailSendGrid)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioEmailSendGrid = servicioEmailSendGrid;
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

        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacto(ContactoViewModel contactoViewModel, IServicioEmailSendGrid servicioEmailSendGrid)
        {
            servicioEmailSendGrid.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }
        public IActionResult Gracias()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}