    public class MyNewClass : MyBaseClass
    {
        public MyExceptionClass() : base()
        {
            //other stuff here
        }
    }
    
    public class MyBaseClass : Controller {
      private bool isRoute;
      private bool isAuthenticated;
    
      MyBaseClass(){
        isReroute = MethodCheckReroute();
        isAuthenticated = MethodCheckAuth();
    
        if (isReroute || !isAuthenticated) {
          Response.RedirectToRoute("Login");
          throw new System.Web.Http.HttpResponseException(
          new HttpResponseMessage(HttpStatusCode.ExpectationFailed));
       }
    }
