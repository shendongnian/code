    using System;
    using System.Diagnostics;
    
    namespace WebApplication11
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (IsPostBack)
                {
                    //any form inputs can be obtained with Request.Form[]
                    Debug.WriteLine(Request.Form["stripetoken"]);
                }
            }
        }
    }
