    using Samples.SampleData;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace PivotTest
    {
        public partial class tempform : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    demo.DataSource = new List<Temp>() {
                        new Temp() { Col1="1"},
                        new Temp() { Col1="1"},
                        new Temp() { Col1="1"},
                        new Temp() { Col1="1"},
                        };
    
                    demo.DataBind();
                }
            }
    
            protected void btnView_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
    
                Response.Redirect("Customer.aspx");
            }
        }
    }
