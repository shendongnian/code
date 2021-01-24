    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Test : System.Web.Services.WebService
    {
        [WebMethod]
        public string getData()
        {
            Dictionary<string, string> name = new Dictionary<string, string>();
            name.Add("1", "Valeur 1");
            name.Add("2", "Valeur 2");
            string myJsonString = (new JavaScriptSerializer()).Serialize(name);
            return myJsonString;        }
    }
