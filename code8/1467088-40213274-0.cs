    public class Global : System.Web.HttpApplication
    {
        protected void Application_Error(object sender, EventArgs e)
        {
            // is there an error ?
            var error = Server.GetLastError();
            if (error != null)
            {
                // mark the error as - "i'll handle it myself"
                Server.ClearError();
                // load error.html manually & dump it to response
                var content = File.ReadAllText(Server.MapPath("~/error.html"));
                Context.Response.Write(content);
                // set correct error code
                Context.Response.StatusCode = 500;
            }
        }
    }
