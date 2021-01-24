    using DemoOdataFunction.Models;
    using System.Web.Http;
    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    
    
    namespace DemoOdataFunction
    {
        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                // Web API configuration and services
    
                // Web API routes
                config.MapHttpAttributeRoutes();
    
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
    
                ODataModelBuilder builder = new ODataConventionModelBuilder();
                builder.Namespace = "MyNamespace";
    
                builder.EntitySet<TestModel>("TestModels");
    
                ActionConfiguration myAction = builder.EntityType<TestModel>().Action("MyAction");
                myAction.Parameter<string>("stringPar");
    
    
                FunctionConfiguration myFunction = builder.EntityType<TestModel>().Collection.Function("MyFunction");
                myFunction.Parameter<int>("parA");
                myFunction.Parameter<int>("parB");
                myFunction.ReturnsFromEntitySet<TestModel>("TestModels");
    
    
                config.MapODataServiceRoute(
                    routeName: "ODataRoute",
                    routePrefix: "odata",
                    model: builder.GetEdmModel()
                    );
            }
        }
    }
