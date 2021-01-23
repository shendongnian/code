    using Swashbuckle.Application;
    using System.Web.Http;
    
    namespace Name.API 
    {
         public class SwaggerConfig
         {
              public static void Register(HttpConfiguration config)
              {
                    config.EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Name.API");   
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
             }
         }
    }
