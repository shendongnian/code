     protected void Application_Error(object sender, EventArgs e)
            {
                Exception exception = Server.GetLastError();
                //Log your exception here
                Response.Clear();
                string action= "Error";
                // clear error on server
                Server.ClearError();
    
                Response.Redirect(String.Format("~/Error/{0}?message={1}", action, exception.Message));
               
            }
