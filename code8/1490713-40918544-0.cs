    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string GetAutoJsonBatches()
        {
            return autoJsonBatches;
        }
    }
