        public class AccountController : System.Web.Mvc.Controller{ 
          public System.Web.Mvc.ActionResult Index(){
            List<object> list = new List<Object>();
            HttpContext.Cache["ObjectList"] = list;                 // add
            list = (List<object>)HttpContext.Cache["ObjectList"]; // retrieve
            HttpContext.Cache.Remove("ObjectList");                 // remove
            return new System.Web.Mvc.EmptyResult();
          }
        }
