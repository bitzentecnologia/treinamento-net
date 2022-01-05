using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoBitzen.Dados.Entidades;
using TreinamentoBitzen.RegrasNegocio.Services;
using TreinamentoBitzen.ViewModels;

namespace TreinamentoBitzen.Controllers
{
    public class DriverController : Controller
    {
        private readonly DriverService _driverService = null;

        public DriverController()
        {
            _driverService = new DriverService();
        }


        #region Actions


        // GET: Driver
        public ActionResult Index()
        {
            var listEntities = _driverService.List();

            // Mapeamento Model x ViewModel

            var listModel = listEntities.Select(x => new DriverViewModel
            {
                Id = x.Id,
                Active = x.Active,
                BirthDate = x.BirthDate,
                CnhCategoryId = x.CnhCategoryId,
                CnhNumber = x.CnhNumber,
                Cpf = x.Cpf,
                Name = x.Name
            }).ToList();

            return View(listModel);
        }

        // GET - DETAILS
        [HttpGet]
        public ActionResult Details(int id)
        {
            var detail = _driverService.GetById(id);
            var viewModel = new DriverViewModel
            {
                Id = id,
                Active = detail.Active,
                BirthDate = detail.BirthDate,
                CnhCategoryId = detail.CnhCategoryId,
                CnhNumber = detail.CnhNumber,
                Cpf = detail.Cpf,
                Name = detail.Name
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
        public ActionResult Create(DriverViewModel viewModel)
        {
            if (viewModel != null && viewModel.Name != null)
            {
                var newModel = new Driver
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Active = viewModel.Active,
                    CnhCategoryId = viewModel.CnhCategoryId,
                    BirthDate = viewModel.BirthDate,
                    CnhNumber = viewModel.CnhNumber,
                    Cpf = viewModel.Cpf
                };
                _driverService.Save(newModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET - EDIT
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var edit = _driverService.GetById(id);
            var viewModel = new DriverViewModel
            {
                Id = id,
                Name = edit.Name,
                Active = edit.Active,
                CnhCategoryId = edit.CnhCategoryId,
                BirthDate = edit.BirthDate,
                CnhNumber = edit.CnhNumber,
                Cpf = edit.Cpf
            };

            return View(viewModel);
        }

        // POST - EDIT
        [HttpPost]
        public ActionResult Edit(DriverViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var obj = new Driver()
                {
                    Id = viewModel.Id,
                    Name=viewModel.Name,
                    Active = viewModel.Active,
                    BirthDate = viewModel.BirthDate,
                    CnhCategoryId = viewModel.CnhCategoryId,
                    CnhNumber = viewModel.CnhNumber,
                    Cpf = viewModel.Cpf
                };

                _driverService.Update(obj);
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion
    }
}