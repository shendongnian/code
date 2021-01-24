    using Swagger.Net.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Results;
    
    namespace Swagger_Test.Controllers
    {
        public class IHttpActionResultController : ApiController
        {
    
            [SwaggerResponse(HttpStatusCode.OK, "List of customers", typeof(IEnumerable<int>))]
            [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
            public IHttpActionResult Post(MyData data)
            {
                throw new NotImplementedException();
            }
        }
    
        /// <summary>My super duper data</summary>
        public class MyData
        {
            /// <summary>The unique identifier</summary>
            public int id { get; set; }
    
            /// <summary>Everyone needs a name</summary>
            public string name { get; set; }
        }
    }
