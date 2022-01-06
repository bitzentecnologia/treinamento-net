using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoBitzen.RegrasNegocio.Services;
using TreinamentoBitzen.ViewModels;

namespace TreinamentoBitzen.Controllers
{
    public class FuelTypeController : Controller
    {
        private readonly FuelTypeService _fuelTypeService = null;

        public FuelTypeController()
        {
            _fuelTypeService= new FuelTypeService();
        }

        #region Actions

        // GET: FuelType
        public ActionResult Index()
        {
            var listEntities = _fuelTypeService.List();

            // Mapeamento Model x ViewModel

            var listModel = listEntities.Select(x => new FuelTypeViewModel
            {
                Id = x.Id,
                Price = x.Price,
                Type = x.Type
            }).ToList();

            return View(listModel);
        }

        // GET - DETAILS
        [HttpGet]
        public ActionResult Details(int id)
        {
            var detail = _fuelTypeService.GetById(id);
            var viewModel = new FuelTypeViewModel
            {
                Id = id,
                Price = detail.Price,
                Type = detail.Type
            };
            return View(viewModel);
        }

        #endregion Actions
    }
}