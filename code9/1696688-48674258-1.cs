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
                Class1 classOne = new Class1();
                string information = classOne.write();
             }
        }
