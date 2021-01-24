        //Inside CustomAuthenticationHandler
        
        private async Task<bool> InvokeReplyPathAsync()
        {
            if (Options.CallbackPath.HasValue && Options.CallbackPath == Request.Path)
            {
                _//InvokeReplyPathAsync: - Match {Request.Path}");
                AuthenticationTicket ticket = await AuthenticateAsync();
                if (ticket == null)
                {
                    // InvokeReplyPathAsync:  Null Ticket Recieved. Unable to redirect.
                    Response.StatusCode = 500;
                    return true;
                }
                //***** IMPORTANT ******WILL CAUSE SEEMINGLY RANDOM LOGOUT IF NOT SET ******* 
                // Defaults to 60 Seconds if not set
                ticket.Properties.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(2); // Set as per your application need
                ticket.Properties.IsPersistent = true; 
                ticket.Properties.IssuedUtc = DateTimeOffset.UtcNow;
