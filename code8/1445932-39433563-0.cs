    public partial class Login : System.Web.UI.Page
    {
        protected async void btnLogin_Click(object sender, EventArgs e)
            {
    
                await request_login();
                if (canLogin == true)
                {
                    Response.Redirect("Dashboard.aspx",false);
                }
             }
    
       private async Task request_login()
            {
                // call web service with httpClient
                   Session["key"] = "session object to be stored";
            }
    }
