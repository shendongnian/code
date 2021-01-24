    using System.Linq;
    using System.Web.Mvc;
    using MvcApplication1.Models;
    
    namespace MvcApplication1.Controllers
    {
         
         public class HomeController : Controller
         {
              public ActionResult Index()
              {
                   var dataContext = new MovieDataContext();
                   int count = (from row in dataContext.Movies
                        where row.IsEnquiry == true
                     select row).Count();
                   ViewBag.ItemCount = count;
                   return View();
              }
         }
    }
    
    
    
        
