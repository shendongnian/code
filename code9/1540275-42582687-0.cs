    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    			if (Request.Form["Car"] == "Volvo") 
    			{
    				Response.Redirect("VolvoHomepage.html");
    			}
    
    			else if (Request.Form["Car"] == "Ford") 
    			{
    				Response.Redirect("FordHomepage.html");
    			}
    			else if (Request.Form["Car"] == "Mercedes") 
    			{
    				Response.Redirect("MercedesHomepage.html");
    			}
    			else if (Request.Form["Car"] == "Audi") 
    			{
    				Response.Redirect("AudiHomepage.html");
    			}
    			else if (Request.Form["Car"] == "Vauxhall") 
    			{
    			    Response.Redirect("VauxhallHomepage.html");
    			}
            }
        }
    }
