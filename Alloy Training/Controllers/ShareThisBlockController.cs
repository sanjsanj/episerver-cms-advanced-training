using System.Web.Mvc;
using Alloy_Training.Models.Blocks;
using Alloy_Training.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;

namespace Alloy_Training.Controllers
{
    public class ShareThisBlockController : BlockController<ShareThisBlock>
    {
        private readonly IPageRouteHelper pageRouteHelper;
        private readonly UrlResolver urlResolver;

        public ShareThisBlockController(IPageRouteHelper pageRouteHelper, UrlResolver urlResolver)
        {
            this.pageRouteHelper = pageRouteHelper;
            this.urlResolver = urlResolver;
        }

        public override ActionResult Index(ShareThisBlock currentBlock)
        {
            var model = new ShareThisBlockViewModel();
            PageData myPageData = pageRouteHelper.Page;
            string internalUrl = urlResolver.GetUrl(myPageData.PageLink);
            var url = new UrlBuilder(internalUrl);
            EPiServer.Global.UrlRewriteProvider.ConvertToExternal(url, null, System.Text.Encoding.UTF8);
            var friendlyUrl = UriSupport.AbsoluteUrlBySettings(url.ToString());
            model.FriendlyUrl = friendlyUrl;
            model.Settings = currentBlock;
            return PartialView(model);
        }
    }
}
