using System.Collections.Generic;
using System.Web.Mvc;
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
            var listViewModels = new List<ManufacterViewModel>();

            // Mapeamento Model X ViewModel
#warning Desafio #1 - Refazer este for com o comando .Select (Linq)
            foreach (var manufacter in listEntities)
            {
                // Opção 1
                var viewModel = new ManufacterViewModel();
                viewModel.Id = manufacter.Id;
                viewModel.Name = manufacter.Name;
                viewModel.Active = manufacter.Active;

                listViewModels.Add(viewModel);

                //// Opção 2 - Simplificar a inicialização do objeto
                //var viewModel2 = new ManufacterViewModel
                //{
                //    Id = manufacter.Id,
                //    Name = manufacter.Name,
                //    Active = manufacter.Active
                //};
                //listViewModels.Add(viewModel2);
            }

            // Preencher os dados na View
            return View(listViewModels);
        }
        #endregion

        #endregion
    }
}