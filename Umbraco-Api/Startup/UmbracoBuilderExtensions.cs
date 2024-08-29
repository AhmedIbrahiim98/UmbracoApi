using Umbraco.Cms.Api.Common.OpenApi;
using Umbraco.Cms.Web.Common.ApplicationBuilder;

namespace Umbraco_Api.Startup;

public static class UmbracoBuilderExtensions
{
    public static IUmbracoBuilder EnableSwaggerInProduction(this IUmbracoBuilder builder)
    {
        builder.Services.Configure<UmbracoPipelineOptions>(options =>
        {
            options.PipelineFilters.RemoveAll(filter => filter is SwaggerRouteTemplatePipelineFilter);
            options.AddFilter(new SwaggerProductionRouteTemplatePipelineFilter());
        });
        return builder;
    }
}