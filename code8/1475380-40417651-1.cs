    public class ListObject
        {
            public string ID { get; set; }
            public string colour { get; set; }
        }
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
            [WebMethod]
            public static string GetCurrentTime(object lists)
            {
    
                List<ListObject> objects = new List<ListObject>();
                Object[] results = (Object[])lists;
    
                foreach (Dictionary<String, Object> result in results)
                {
                    var properties = result as Dictionary<string, object>;
                    List<String> propertyNames = new List<string>();
                    String ID=String.Empty;
                    String colour = String.Empty;
                    int idFlag = 0;
                    foreach (var p in properties)
                    {
                        if (idFlag == 0)
                        {
                            ID= p.Value.ToString();
                            idFlag = 1;
                        }
                        else
                        {
                            colour = p.Value.ToString();
                        }
                        //String sjs = p.ToString().Replace("[","").Replace("]","").Split(',')[1];
    
                    }
                   
                         objects.Add(new ListObject
                    {
                        ID = ID,
                        colour = colour
                    });
                }
    
    
                return "text string";
            }
        }
