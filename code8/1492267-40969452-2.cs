    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    
    public class NewsItemController : ApiController
    {
        public IEnumerable<NewsItemVM> Get([ModelBinder(typeof(PaginationModelBinder))]PagingParamsVM pegination)
        {
            //Validate(pegination); //if I call this explicitly ModelState.IsValid is set correctly.
            var valid = ModelState.IsValid; //this is always true
            return Enumerable.Empty<NewsItemVM>();
        }
    }
