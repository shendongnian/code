    using Microsoft.AspNetCore.Mvc;
    using WebApplication1.Entities.Contracts;
    
    namespace WebApplication1.Controllers
    {
        public class PayerController : Controller
        {
            private readonly IPayerManager _payerManager;
    
            public PayerController(IPayerManager payerManager)
            {
                _payerManager = payerManager;
            }
    
            public IActionResult Index()
            {
                //Both methods in PayerManager due to heritage (PayerManager : IPayerManager)
                _payerManager.IAMCommon(); 
                _payerManager.MyPayer(); 
    
                return View();
            }
        }
    }
