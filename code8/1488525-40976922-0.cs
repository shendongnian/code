    public class DataObjectTypeRoutingConvention : IODataRoutingConvention
    {
       public string SelectAction(ODataPath odataPath, HttpControllerContext controllerContext, ILookup<string, HttpActionDescriptor> actionMap)
       {
         return null;
       }
       public string SelectController(ODataPath odataPath, HttpRequestMessage request)
       {
         if (odataPath.PathTemplate.StartsWith("~/entityset",System.StringComparison.InvariantCultureIgnoreCase))
           return "DataObjects";
         else
          return null;
      }
    }
