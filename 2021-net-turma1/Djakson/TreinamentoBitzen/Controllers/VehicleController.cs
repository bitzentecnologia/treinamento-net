using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoBitzen.RegrasNegocio.Services;
using TreinamentoBitzen.ViewModels;

namespace TreinamentoBitzen.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VehicleService _vehicleService = null;

        public VehicleController()
        {
            _vehicleService = new VehicleService();
        }

        #region Actions

        #region Index

        // GET: Vehicle
        [HttpGet]
        public ActionResult Index()
        {
            var listEntities = _vehicleService.List();

            var listModel = listEntities.Select(x => new VehicleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,
                LicensePlate = x.LicensePlate,
                FuelType = x.FuelType,
                FuelTypesId = x.FuelTypesId,
                Manufacturer = x.Manufacturer,
                ManufacturersId = x.ManufacturersId,
                ManufactureYear = x.ManufactureYear,
                Remarks = x.Remarks,
                TankCapacity = x.TankCapacity
            }).ToList();

            return View(listModel);
        }

        #endregion

        #endregion
    }
}