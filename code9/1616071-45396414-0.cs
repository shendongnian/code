    public class HelloWorldController : Controller
        {
            // 
            // GET: /HelloWorld/
     
            public string Index()
            {
                return "Hello World !!";
            }
     
            // 
            // GET: /HelloWorld/Welcome/ 
     
            public string welcome()
            {
                return "Welcome to .NET Core!!";
            }
        }
