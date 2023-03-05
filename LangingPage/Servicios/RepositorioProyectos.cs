using LangingPage.Models;

namespace LangingPage.Servicios
{

    public interface IRepositorioProyectos
    {
        List<ProyectosDTO> ObtenerProyectos();
    }

    public class RepositorioProyectos: IRepositorioProyectos
    {
        public List<ProyectosDTO> ObtenerProyectos()
        {
            return new List<ProyectosDTO>()
            {
                new ProyectosDTO
                {
                    Titulo = "Tienda en Linea",
                    Descripcion = "Desarrollo Web en PHP, MVC, POO y MySQL - Tienda Virtual",
                    Link = "#",
                    ImagenURL= "/imgs/TiendaLinea.png"
                },
                new ProyectosDTO
                {
                    Titulo = "Sistema de inventarios",
                    Descripcion = "Sistema para menejo de inventarios, compra y ventas en WindowsForms C# y SqlServer",
                    Link = "#",
                    ImagenURL= "/imgs/folio-2.jpg"
                },
                new ProyectosDTO
                {
                    Titulo = "Manejo de Presupuestos",
                    Descripcion = "Proyecto de manejo de presupuestos sencillo donde nuestros usuarios van a poder ingresar sus movimientos financieros, para así saber en qué gastan su dinero",
                    Link = "#",
                    ImagenURL= "/imgs/folio-3.jpg"
                }
            };
        }
    }
}
