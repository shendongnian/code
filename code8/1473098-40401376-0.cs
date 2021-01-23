    public class ContentServerController : Controller
    {  
         // one public Action-Method which reads the "command" from query-string
         // and calls different private methods according to commandName          
         public ActionResult ContentServer(string contRep, string docId, string pVersion)
         {
             string commandName = Request.QueryString[0];
             switch(commandName)
             {
                 case "info":
                     return info(contRep, docId, pVersion);
                 case "get":
                     return get(contRep, docId, pVersion);
                 case "create":
                     return create(contRep, docId);
                 default:
                     throw new NotImplementedException();
             }
         private ActionResult info(string contRep, string docId, string pVersion)
         {
             throw new NotImplementedException();
         }
         private ActionResult get(string contRep, string docId, string pVersion)
         {
             throw new NotImplementedException();
         }  
         private ActionResult create(string contRep, string docId)
         {
             throw new NotImplementedException();
         }  
    }
