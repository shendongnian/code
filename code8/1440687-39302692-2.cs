    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    
    namespace DemonstrationOne
    {
        public partial class Demo : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            { }
    
            protected void ShowLabel(object sender, EventArgs e)
            {
                showLiteral.Visible = true;
                HelloWorldLabel.Text = "Work damnitt aarrgghh!!";
            }
        }
    }
