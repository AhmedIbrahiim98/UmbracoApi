using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Core;
using Umbraco.Cms.Web.Common.Controllers;

namespace Umbraco_Api.Controllers;


[Route("umbraco/api/[controller]")]
public class HomepageApiController : UmbracoApiController
{
    private readonly IUmbracoContextFactory _umbracoContextFactory;
    private readonly IPublishedContentQuery _publishedContentQuery;

    public HomepageApiController(
        IUmbracoContextFactory umbracoContextFactory,
        IPublishedContentQuery publishedContentQuery)
    {
        _umbracoContextFactory = umbracoContextFactory;
        _publishedContentQuery = publishedContentQuery;
    }

    [HttpGet("home")]
    public IActionResult GetHomepage()
    {
        using (_umbracoContextFactory.EnsureUmbracoContext())
        {
            // Fetch homepage by its content type alias (e.g., "home") or ID
            var homepage = _publishedContentQuery.ContentAtRoot()
                                .FirstOrDefault(c => c.ContentType.Alias == "home");

            if (homepage == null)
            {
                return NotFound("Homepage not found.");
            }

            // Prepare a custom response with the necessary homepage properties
            var homepageData = new
            {
                id = homepage.Id,
                name = homepage.Name,
                //url = homepage.Url,
                properties = homepage.Properties.ToDictionary(x => x.Alias, x => x.GetValue())
            };

            return Ok(homepageData);
        }
    }
}

// https://localhost:44385/umbraco/api/homepageapi/homepage