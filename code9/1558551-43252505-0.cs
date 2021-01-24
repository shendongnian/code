    [WebService, ScriptService]
    public class WebService1 : WebService
    {
        [WebMethod]
        public string names(string name)
        {
            return "Hello " + name;
        }
    }
