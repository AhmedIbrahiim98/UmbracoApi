using Umbraco.Cms.Api.Common.OpenApi;

namespace Umbraco_Api.Startup;

public class SwaggerProductionRouteTemplatePipelineFilter() : SwaggerRouteTemplatePipelineFilter("umbraco")
{
    protected override bool SwaggerIsEnabled(IApplicationBuilder applicationBuilder) => true;
}