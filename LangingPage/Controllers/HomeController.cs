using LangingPage.Models;
using LangingPage.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LangingPage.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IServicioEmail servicioEmail;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos, IServicioEmail servicioEmail)
		{
			_logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioEmail = servicioEmail;
        }

		public IActionResult Index()
		{			
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
			var modelo = new HomeIndexViewModel()
			{
				Proyectos = proyectos
			};

			return View(modelo);
		}

		[HttpPost]
		public async Task<IActionResult> Contacto(ContactoDTO contactoDTO)
		{
			await servicioEmail.Enviar(contactoDTO);
			//Mostrar mensaje de enviado
			return RedirectToAction("Gracias");
		}
		public IActionResult Gracias()
		{
			return View();
		}
		  
		public IActionResult Proyectos()
		{
			var proyectos = repositorioProyectos.ObtenerProyectos();
			return View(proyectos);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}