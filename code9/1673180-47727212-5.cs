    public class SomeContoller: Controller
    {
          private readonly SomeServiceThatUsesCookie _someService;
    
          public SomeContoller(SomeServiceThatUsesCookie someService){
                 _someService = someService;
          }
    
          public string GetCookieValue(string name){
                 return _someService.IWonnaCookie(name);
          }
    }
