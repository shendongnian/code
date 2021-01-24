    public class HomeModule : NancyModule
    {
       public HomeModule(IMyDictionary dict)
       {
         Get["/"] => dict;
       }
  }
            
