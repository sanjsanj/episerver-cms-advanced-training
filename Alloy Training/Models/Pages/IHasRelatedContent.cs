using EPiServer.Core;

namespace Alloy_Training.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
