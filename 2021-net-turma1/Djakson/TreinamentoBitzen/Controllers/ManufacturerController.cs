using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TreinamentoBitzen.Dados.Entidades;
using TreinamentoBitzen.RegrasNegocio.Services;
using TreinamentoBitzen.ViewModels;

namespace TreinamentoBitzen.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly ManufacturerService _manufacturerService = null;

        public ManufacturerController()
        {
            _manufacturerService = new ManufacturerService();
        }

        #region Actions

        #region Index
        [HttpGet]
        public ActionResult Index()
        {
            var listEntities = _manufacturerService.List();

            // Mapeamento Model X ViewModel

            var listModels = listEntities.Select(x => new ManufacturerViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active
            }).ToList();

            return View(listModels);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var detail = _manufacturerService.GetById(id);
            var viewModel = new ManufacturerViewModel
            {
                Id = id,
                Name = detail.Name,
                Active = detail.Active
            };

            return View(viewModel);
        }

        // GET - CREATE
        public ActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        public ActionResult Create(ManufacturerViewModel viewModel)
        {
            if (viewModel != null && viewModel.Name != null)
            {
                var newModel = new Manufacturer
                {
                    Name = viewModel.Name,
                    Active = viewModel.Active
                };

                _manufacturerService.Save(newModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET - EDIT
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var edit = _manufacturerService.GetById(id);
            var viewModel = new ManufacturerViewModel
            {
                Id = id,
                Name = edit.Name,
                Active = edit.Active
            };

            return View(viewModel);
        }

        // POST - EDIT (EndPoint não encontrado via PUT?)
        [HttpPost]
        public ActionResult Edit(ManufacturerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var obj = new Manufacturer()
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Active = viewModel.Active
                };

                _manufacturerService.Update(obj);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET - DELETE
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var detail = _manufacturerService.GetById(id);
            var viewModel = new ManufacturerViewModel
            {
                Id = id,
                Name = detail.Name,
                Active = detail.Active
            };

            return View(viewModel);
        }

        // DELETE - DELETE
        [HttpPost]
        public ActionResult Delete(ManufacturerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _manufacturerService.DeleteById(viewModel.Id);
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion

        #endregion
    }
}