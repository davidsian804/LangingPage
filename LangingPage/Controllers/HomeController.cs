using LangingPage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LangingPage.Controllers
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
			var proyectos = ObtenerProyectos().Take(3).ToList();
			var modelo = new HomeIndexViewModel()
			{
				Proyectos = proyectos
			};

			return View(modelo);
		}


		private List<ProyectosDTO> ObtenerProyectos()
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