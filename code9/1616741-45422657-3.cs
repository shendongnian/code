    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class DataTablesLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}
    
        [WebMethod]
        public static string LoadData()
        {
            JObject returnObject = new JObject(new JProperty("options", new List<JObject>()),
                          new JProperty("files", new List<JObject>()));
    
            List<JObject> data = new List<JObject>();
    
            JObject datum = new JObject(new JProperty("DT_RowId", "row_" + 1),
                    new JProperty("name", "Hogarth Fortith"),
        
            new JProperty("age", 34),
                new JProperty("lunch", "Apple"),
                new JProperty("id", 123));
        data.Add(datum);
        datum = new JObject(new JProperty("DT_RowId", "row_" + 2),
                new JProperty("name", "Keely Kline"),
                new JProperty("age", 23),
                new JProperty("lunch", "Orange"),
                new JProperty("id", 124));
        data.Add(datum);
        datum = new JObject(new JProperty("DT_RowId", "row_" + 3),
                new JProperty("name", "John Owen"),
                new JProperty("age", 54),
                new JProperty("lunch", "Sandwich"),
                new JProperty("id", 125));
        data.Add(datum);
        returnObject.Add(new JProperty("data", data));
        return returnObject.ToString();
        }
    }
