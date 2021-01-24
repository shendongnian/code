        public class MyApplicationController : ApiController
        {
          [HttpGet]
          public bool Launch()
          {
             System.Diagnostics.Process.Start("MyApp.exe");
             return true;
          }
        }
