javascript
{
  "MySettings": {
    "MyArray": [
      "str1",
      "str2",
      "str3"
    ]
  }
}
Create a class representing your section :
    public class MySettings
    {
         public List<string> MyArray {get; set;}
    }
In your application startup class, bind your model an inject it in the DI service :
    services.Configure<MySettings>(options => Configuration.GetSection("MySettings").Bind(options));
And in your controller, get your configuration data from the DI service :
    public class HomeController : Controller
    {
        private readonly List<string> _myArray;
    
        public HomeController(IOptions<MySettings> mySettings)
        {
            _myArray = mySettings.Value.MyArray;
        }
    
        public IActionResult Index()
        {
            return Json(_myArray);
        }
    }
You can also store your entire configuration model in a property in your controller, if you need all the data :
    public class HomeController : Controller
    {
        private readonly MySettings _mySettings;
    
        public HomeController(IOptions<MySettings> mySettings)
        {
            _mySettings = mySettings.Value;
        }
    
        public IActionResult Index()
        {
            return Json(_mySettings.MyArray);
        }
    }
The ASP.NET Core's dependency injection service works just like a charm :)
