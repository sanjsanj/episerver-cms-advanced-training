using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Alloy_Training.Models.Blocks
{
    [ContentType(
        DisplayName = "Share This",
        GUID = "49a1f678-0c71-487a-acca-2e7dad6ed3f2",
        Description = "Allows a visitor to share a link to a page via Twitter, Facebook, or LinkedIn.")]
    [SiteImageUrl]
    public class ShareThisBlock : BlockData
    {
        [Display(
        Name = "Display Facebook share",
        GroupName = SystemTabNames.Content,
        Order = 100)]
        public virtual bool ShareToFacebook { get; set; }
        [Display(
        Name = "Display Twitter share",
        GroupName = SystemTabNames.Content,
        Order = 200)]
        public virtual bool ShareToTwitter { get; set; }
        [Display(
        Name = "Display LinkedIn share",
        GroupName = SystemTabNames.Content,
        Order = 300)]
        public virtual bool ShareToLinkedin { get; set; }
        public override void SetDefaultValues(ContentType contentType)
        {
            ShareToFacebook = true;
            ShareToTwitter = true;
            ShareToLinkedin = true;
        }
    }
}