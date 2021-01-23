        namespace WebApplication1
        {    // a class in context with how the data are is being used
            [Serializable]
            public class select2Item
            {
                public String id { get; set; }
                public String text { get; set; }
                public select2Item(String code, String name)
                {
                    this.id = code;
                    this.text = name;
                }
                public select2Item() { }
            }
            /// <summary>
            /// Summary description for WebService1
            /// </summary>
            [WebService(Namespace = "http://tempuri.org/")]
            [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
            [System.ComponentModel.ToolboxItem(false)]
            [System.Web.Script.Services.ScriptService]
            public class WebService1 : System.Web.Services.WebService
            {
                [WebMethod]
                public string GetAList()
                {
                    System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
                    return makelist();
                }
                 // return a list of serialized codes and countries
                public String makelist()
                {
                    List<select2Item> list = new List<select2Item>();
                    list.Add(new select2Item("AI", "Anguilla"));
                    list.Add(new select2Item("AQ", "Antarctica"));
                    list.Add(new select2Item("AG", "Antigua and Barbuda"));
                    list.Add(new select2Item("AR", "Argentina"));
                    list.Add(new select2Item("AM", "Armenia"));
                    list.Add(new select2Item("AW", "Aruba"));
                    list.Add(new select2Item("AU", "Australia"));
                    list.Add(new select2Item("AT", "Austria"));
                    list.Add(new select2Item("AZ", "Azerbaijan"));
                    list.Add(new select2Item("BS", "Bahamas"));
                    list.Add(new select2Item("BH", "Bahrain"));
                    list.Add(new select2Item("BD", "Bangladesh"));
                    list.Add(new select2Item("BB", "Barbados"));
                    list.Add(new select2Item("BY", "Belarus"));
                    list.Add(new select2Item("BE", "Belgium"));
                    list.Add(new select2Item("BZ", "Belize"));
                    // did it this way to show you which to use
                    System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
                    String jsonList = ser.Serialize(list);
                    return jsonList;
                }
             }
        }
