    using System;
    using System.Linq;
    using System.Web.Http;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using Swashbuckle.AspNetCore.Swagger;
    
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    
    internal class SwaggerFilterOutControllers : IDocumentFilter
    {
    
        void IDocumentFilter.Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var item in swaggerDoc.Paths.ToList())
            {
                if (!(item.Key.ToLower().Contains("/api/endpoint1") ||
                      item.Key.ToLower().Contains("/api/endpoint2")))
                {
                    swaggerDoc.Paths.Remove(item.Key);
                }
            }
            swaggerDoc.Definitions.Remove("Model1");
            swaggerDoc.Definitions.Remove("Model2");
        }
    }
