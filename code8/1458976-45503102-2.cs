    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData;
    using Microsoft.AspNetCore.OData.Abstracts;
    using Microsoft.AspNetCore.OData.Query;
    using System.Linq;
    
    namespace WebApplication1.Controllers
    {
        [Produces("application/json")]
        [Route("api/Entity")]
        public class ApiController : Controller
        {
            // note how you can use whatever endpoint
            [HttpGet("all")]
            public IQueryable<MyEntity> Get()
            {
                // plug your entities source (database or whatever)
                var entities = new[] {
                    new MyEntity{ EntityID = 1, SomeText = "Test 1" },
                    new MyEntity{ EntityID = 2, SomeText = "Test 2" },
                    new MyEntity{ EntityID = 3, SomeText = "Another texts" },
                }.AsQueryable();
    
                var modelManager = (IODataModelManger)HttpContext.RequestServices.GetService(typeof(IODataModelManger));
                var model = modelManager.GetModel(nameof(WebApplication1));
                var queryContext = new ODataQueryContext(model, typeof(MyEntity), null);
                var queryOptions = new ODataQueryOptions(queryContext, HttpContext.Request);
    
                return queryOptions
                    .ApplyTo(entities, new ODataQuerySettings
                    {
                        HandleNullPropagation = HandleNullPropagationOption.True
                    })
                    .Cast<MyEntity>();
            }
        }
    }
