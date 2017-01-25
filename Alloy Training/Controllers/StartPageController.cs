using System.Web.Mvc;
using Alloy_Training.Models.Pages;
using Alloy_Training.Models.ViewModels;
using EPiServer.Core;
using EPiServer.Logging;
using EPiServer.Web;
using EPiServer.Web.Mvc;

namespace Alloy_Training.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        private static readonly ILogger logger = LogManager.GetLogger(typeof(StartPageController));
        public ActionResult Index(StartPage currentPage)
        {
            if (PageReference.IsNullOrEmpty(currentPage.SearchPageLink))
            {
                logger.Error("No 'Search page' is specified in 'Site settings'.");
            }
            var model = PageViewModel.Create(currentPage);

            if (SiteDefinition.Current.StartPage.CompareToIgnoreWorkID(currentPage.ContentLink)) // Check if it is the StartPage or just a page of the StartPage type.
            {
                //Connect the view models logotype property to the start page's to make it editable
                var editHints = ViewData.GetEditHints<PageViewModel<StartPage>, StartPage>();
                editHints.AddConnection(m => m.Layout.Logotype, p => p.SiteLogotype);
                editHints.AddConnection(m => m.Layout.ProductPages, p => p.ProductPageLinks);
                editHints.AddConnection(m => m.Layout.CompanyInformationPages, p => p.CompanyInformationPageLinks);
                editHints.AddConnection(m => m.Layout.NewsPages, p => p.NewsPageLinks);
                editHints.AddConnection(m => m.Layout.CustomerZonePages, p => p.CustomerZonePageLinks);
            }

            return View(model);
        }

    }
}
