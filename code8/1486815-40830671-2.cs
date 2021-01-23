    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod(CacheDuration=10)]
        public string GetDate1()
        {
            return DateTime.Now.ToString();
        }
        [WebMethod]
        public string GetDate2()
        {
            return this.GetDate1();
        }
    }
