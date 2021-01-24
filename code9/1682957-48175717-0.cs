    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
        public partial class _Default : Page
        {
    
            private List<string> data = new List<string>() { "1", "2", "3", "4", "5" };
    
            protected void Page_Load(object sender, EventArgs e)
            {
                // convert the C# object into a JSON string
                string arrayJson = JsonConvert.SerializeObject(data);
                // AND/OR output the JSON string to a <label> on the page
                lblArray.Text = arrayJson;
            }
        }
    }
