    using System;
    namespace Test
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                gvOpportunity.DataSource = new[] {
                    new { ID=1,Value="First" },
                    new { ID=2,Value="Second" },
                    new { ID=3,Value="Third" },
                    new { ID=4,Value="Fourth" }
                };
                gvOpportunity.DataBind();
            }
        }
    }
