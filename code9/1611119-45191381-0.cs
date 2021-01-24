     protected void Application_Error(Object sender, EventArgs e)
        {
            try
            {
                var exception = Server.GetLastError();
                 ....
     }
    }
