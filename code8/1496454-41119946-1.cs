        public class DateTimeModelBinder : System.Web.Http.ModelBinding.IModelBinder
        {
            public bool BindModel(HttpActionContext actionContext, System.Web.Http.ModelBinding.ModelBindingContext bindingContext)
            {
                if (bindingContext.ModelType != typeof(DateTime?)) return false;
                
                long result;
    
                if  (!long.TryParse(actionContext.RequestContext.RouteData.Values["from"].ToString(), out result)) 
                    return false;
                    
                bindingContext.Model = new DateTime(result);
    
                return bindingContext.ModelState.IsValid;
            }
        }
        [System.Web.Http.HttpGet]
        [Route("api/v1/Product/{site}/{start?}/{pageSize?}/{from?}")]
        public IHttpActionResult Product(Site site, 
                                         int start = 1, 
                                         int pageSize = 100,
                                         [System.Web.Http.ModelBinding.ModelBinderAttribute(typeof(DateTimeModelBinder))] DateTime? fromLastUpdated = null)   
        {
            // your code
        }
