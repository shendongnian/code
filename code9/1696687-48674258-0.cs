        using System;
        using System.Data;
        using System.Configuration;
        using System.Web;
        using System.Web.Security;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        using System.Text;
        using FineUI.Examples;
        
        namespace FineUIProject
        {
        
            protected void page_load(object sender, EventArgs e) 
            {
                string information = Class1.write();
             }
        }
