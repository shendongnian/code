    using Microsoft.AspNetCore.Mvc;
    using WebApplication1.Entities.Contracts;
    
    namespace WebApplication1.Controllers
    {
        public class BusinessController : Controller
        {
            private readonly IBusinessManager _businessManager;
    
            public BusinessController(IBusinessManager businessManager)
            {
                _businessManager = businessManager;
            }
    
            public IActionResult Index()
            {
                //Both methods in BusinessManager due to heritage (BusinessManager : IBusinessManager)
                _businessManager.IAMCommon(); 
                _businessManager.MyBusiness();
    
                return View();
            }
        }
    }
