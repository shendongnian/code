                var mvcContext = context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext;
            if (mvcContext != null)
            {
                // Use the UserInfo endpoint to get the user's claims
                var discoveryClient = new DiscoveryClient("http://localhost:5000");
                var doc = await discoveryClient.GetAsync();
                var accessToken = await mvcContext.HttpContext.Authentication.GetTokenAsync("access_token");
                var userInfoClient = new UserInfoClient(doc.UserInfoEndpoint);
                var response = await userInfoClient.GetAsync(accessToken);
                var claims = response.Claims;
            }
