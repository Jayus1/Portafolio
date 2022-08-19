using Portafolio.Models;

namespace Portafolio.Servicio
{
    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyecto();
    }
    public class RepositorioProyectos: IRepositorioProyectos
    {
        public List<Proyecto> ObtenerProyecto()
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
    }
}
