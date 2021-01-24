    using DemoOdataFunction.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    using System.Web.OData.Query;
    namespace DemoOdataFunction.Controllers
    {
        public class TestModelsController : ODataController
        {
            IQueryable<TestModel> testModelList = new List<TestModel>()
                {
                    new TestModel{
                    MyProperty = 1,
                    MyString = "Hello"
                    }
                }.AsQueryable();
    
            [EnableQuery]
            public IQueryable<TestModel> Get()
            {
                return testModelList;
            }
    
            [EnableQuery]
            public SingleResult<TestModel> Get([FromODataUri] int key)
            {
    
                IQueryable<TestModel> result = testModelList.Where(t => t.MyProperty == 1);
                return SingleResult.Create(result);
            }
    
            [HttpPost]
            public IHttpActionResult MyAction([FromODataUri] int key, ODataActionParameters parameters)
            {
                string stringPar = parameters["stringPar"] as string;
    
                return Ok();
            }
    
            [HttpGet]
            [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All, MaxExpansionDepth = 2)]
            public  IHttpActionResult MyFunction(int parA, int parB)
            {
                return Ok(testModelList);
            }
        }
    }
