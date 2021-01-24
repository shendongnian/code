    [WebService(Namespace = "http://YourNameSpaceGoesHere/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ReportDepartmentService: System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string SaveXml(string year, string month, string someString)
        {
            string returnMessage = string.Empty;
            // Remaining code goes here.....
            // Assign Success/error message to your returnMessage. 
            return returnMessage;
        }
    }
