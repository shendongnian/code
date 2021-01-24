    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace WebApplication2
    {
        public partial class WebForm2 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                Panel panel1 = (Panel)Master.FindControl("Panel1");
                panel1.Visible = false;
            }
        }
    }
