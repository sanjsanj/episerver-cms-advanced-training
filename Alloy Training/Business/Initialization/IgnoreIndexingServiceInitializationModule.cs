using System.Web.Routing;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace Alloy_Training.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class IgnoreIndexingServiceInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            RouteTable.Routes.Ignore("IndexingService/IndexingService.svc/{*pathInfo}");
            //Add initialization logic, this method is called once after CMS has been initialized
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }
}