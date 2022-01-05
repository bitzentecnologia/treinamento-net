using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        #endregion
    }
}