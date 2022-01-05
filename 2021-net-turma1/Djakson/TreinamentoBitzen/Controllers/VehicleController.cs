using System.Linq;
using System.Web.Mvc;
using TreinamentoBitzen.Dados.Entidades;
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

            // Mapeamento Model X ViewModel

            var listModel = listEntities.Select(x => new VehicleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,
                LicensePlate = x.LicensePlate,
                //FuelType = x.FuelType,
                FuelTypesId = x.FuelTypesId,
                //Manufacturer = x.Manufacturer,
                ManufacturersId = x.ManufacturersId,
                ManufactureYear = x.ManufactureYear,
                Remarks = x.Remarks,
                TankCapacity = x.TankCapacity
            }).ToList();

            return View(listModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var detail = _vehicleService.GetById(id);
            var viewModel = new VehicleViewModel
            {
                Id = id,
                Name = detail.Name,
                Active = detail.Active,
                FuelTypesId = detail.FuelTypesId,
                LicensePlate = detail.LicensePlate,
                ManufacturersId = detail.ManufacturersId,
                ManufactureYear = detail.ManufactureYear,
                Remarks = detail.Remarks,
                TankCapacity = detail.TankCapacity
            };

            return View(viewModel);
        }

        // GET - CREATE
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        public ActionResult Create(VehicleViewModel viewModel)
        {
            if (viewModel != null && viewModel.Name != null)
            {
                var newModel = new Vehicle
                {
                    Name = viewModel.Name,
                    Active = viewModel.Active,
                    FuelType = viewModel.FuelType,
                    FuelTypesId = viewModel.FuelTypesId,
                    Id = viewModel.Id,
                    LicensePlate = viewModel.LicensePlate,
                    Manufacturer = viewModel.Manufacturer,
                    ManufacturersId = viewModel.ManufacturersId,
                    ManufactureYear = viewModel.ManufactureYear,
                    Remarks = viewModel.Remarks,
                    TankCapacity = viewModel.TankCapacity
                };
                _vehicleService.Save(newModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET - EDIT
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var edit = _vehicleService.GetById(id);
            var viewModel = new VehicleViewModel
            {
                Id = id,
                Active = edit.Active,
                FuelTypesId = edit.FuelTypesId,
                LicensePlate = edit.LicensePlate,
                ManufacturersId = edit.ManufacturersId,
                ManufactureYear = edit.ManufactureYear,
                Name = edit.Name,
                Remarks = edit.Remarks,
                TankCapacity = edit.TankCapacity
            };

            return View(viewModel);
        }

        // POST - EDIT
        [HttpPost]
        public ActionResult Edit(VehicleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var obj = new Vehicle()
                {
                    Id = viewModel.Id,
                    Active = viewModel.Active,
                    FuelTypesId = viewModel.FuelTypesId,
                    LicensePlate = viewModel.LicensePlate,
                    ManufacturersId = viewModel.ManufacturersId,
                    ManufactureYear = viewModel.ManufactureYear,
                    Name = viewModel.Name,
                    Remarks = viewModel.Remarks,
                    TankCapacity = viewModel.TankCapacity
                };

                _vehicleService.Update(obj);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET - DELETE
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var detail = _vehicleService.GetById(id);
            var viewModel = new VehicleViewModel
            {
                Active = detail.Active,
                Id = id,
                FuelTypesId = detail.FuelTypesId,
                LicensePlate = detail.LicensePlate,
                ManufacturersId = detail.ManufacturersId,
                ManufactureYear = detail.ManufactureYear,
                Name = detail.Name,
                Remarks = detail.Remarks,
                TankCapacity = detail.TankCapacity
            };

            return View(viewModel);
        }

        // POST - DELETE
        [HttpPost]
        public ActionResult Delete(VehicleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.DeleteById(viewModel.Id);
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion

        #endregion
    }
}