    using System;
    using System.Web.Http.Description;
    using Swashbuckle.Swagger;
    
    internal class SwaggerFilterOutControllers : IDocumentFilter
    {
        void IDocumentFilter.Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            foreach (ApiDescription apiDescription in apiExplorer.ApiDescriptions)
            {
                Console.WriteLine(apiDescription.Route.RouteTemplate);
    
                if ((apiDescription.RelativePathSansQueryString().StartsWith("api/System/"))
                    || (apiDescription.RelativePath.StartsWith("api/Internal/"))
                    || (apiDescription.Route.RouteTemplate.StartsWith("api/OtherStuff/"))
                    )
                {
                    swaggerDoc.paths.Remove("/" + apiDescription.Route.RouteTemplate.TrimEnd('/'));
                }
            }
        }
    }
