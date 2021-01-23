    Class A
    {
           IEnvironmentDataFacade _environmentDataFacade;
           Class A(IEnvironmentDataFacade environmentDataFacade)
           {
                _environmentDataFacade = environmentDataFacade;
           }
    
           public void method xx()
           {
                //Now you can fake IEnvironmentDataFacade:
                 String culture= _environmentDataFacade.GetCulture();
                 //Do the same as above with the method here:
                 boolean implmentApi=Api.GetEnvironmentData().DoImplmentApi();
                 //This is the problem area.
          }
    }
    
    public class EnvironmentDataFacade : IEnvironmentDataFacade
    {
          public string GetCulture()
          {
                return Api.GetEnvironmentData().GetCulture();
          }
    
    
    }
    
    public interface IEnvironmentDataFacade
    {
          string GetCulture();
    }
