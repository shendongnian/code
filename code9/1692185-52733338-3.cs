        private async Task HandleOnCreatingTicket(OAuthCreatingTicketContext context)
        {
            var user = context.Identity;
            // please use better logic than GivenName. Demonstration purposes only.
            if(user.Claims.FirstOrDefault(m=>m.Type==ClaimTypes.GivenName).Value == "MY_FAVORITE_USER")
            {
                user.AddClaim(new Claim(ClaimTypes.Role, "Administrator"));
            }
            await Task.CompletedTask;
        }
        private async Task HandleOnRemoteFailure(RemoteFailureContext context)
        {
            // add your logic here.
            await Task.CompletedTask;
        }
