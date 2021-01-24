      public class BaseController : Controller
      {
         [Inject]
         public IUnitOfWork UnitOfWork { get; set; }
         private readonly ISomeService _someService ;
         public BaseController(ISomeService someService)
         {
             _someService = someService;
         }
         public void Contacts()
         {
             contacts = _someService .GetById(1);
             ViewBag.someThing = contacts; //Add whatever
         }
         public BaseController()
         {
              _someService = DependencyResolver.Current.GetService<ISomeService >();
         }
    }
