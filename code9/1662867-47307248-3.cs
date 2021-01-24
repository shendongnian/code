    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace Stack_Overflow
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
            {
                Label6.Visible = true;
                Label7.Visible = true;
                Label8.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                TextBox1.ReadOnly = false;
            }
    
            protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
            {
                Label6.Visible = false;
                Label7.Visible = false;
                Label8.Visible = false;
                TextBox2.Visible = false;
                TextBox3.Visible = false;
                TextBox4.Visible = false;
            }
        }
    }
