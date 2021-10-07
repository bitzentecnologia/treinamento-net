using System.Web.Mvc;
using TreinamentoBitzen.RegrasNegocio.Services;

namespace TreinamentoBitzen.Controllers
{
    public class ManufacterController : Controller
    {
        private readonly ManufacturerService _manufacturerService = null;

        public ManufacterController()
        {
            _manufacturerService = new ManufacturerService();
        }

        /// <summary>
        /// Listar Todas as Entidades
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var listManufacturers = _manufacturerService.List();
            // ViewModel x Model
            return View();
        }
    }
}