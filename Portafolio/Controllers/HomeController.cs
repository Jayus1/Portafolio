using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            var proyectos= ObtenerProyecto().Take(3).ToList();
            var modelo= new HomeIndexViewModel(){ Proyectos = proyectos};
            return View(modelo);
        }

        private List<Proyecto> ObtenerProyecto()
        {
            return new List<Proyecto>() {
                new Proyecto()
            {

                Titulo = "Amazon",
                Descripcion = "E-Commerce Realista con ASP",
                Link = "https://amazon.com",
                ImagenURL = "/imagenes/amazon.png"

            },
                 new Proyecto()
            {

                Titulo = "New York Times",
                Descripcion = "Pagina de noticias en React",
                Link = "https://nytimes.com",
                ImagenURL = "/imagenes/nyt.png"

            }, new Proyecto()
            {

                Titulo = "Reddit",
                Descripcion = "Red social para compartir en comunidades",
                Link = "https://reddot.com",
                ImagenURL = "/imagenes/reddit.png"

            }, new Proyecto()
            {

                Titulo = "Steam",
                Descripcion = "Tienda en linea para comprar videojuegos",
                Link = "https://store.steampowered.com",
                ImagenURL = "/imagenes/stram.png"

            }
            };
         }

        public IActionResult Privacy()
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