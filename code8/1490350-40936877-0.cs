        /// <summary>
        /// Login as another user (using only a username)
        /// </summary>
        /// <returns>token key</returns>
        [Authorize(Roles = "Admin")]
        [Route("LoginAs")]
        public async Task<IHttpActionResult> GetLoginAs(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return new System.Web.Http.Results.ResponseMessageResult(
                    Request.CreateErrorResponse(
                        (HttpStatusCode)422,
                        new HttpError("UserName null or empty")));
            try
            {
                var userIdentity = UserManager.FindByNameAsync(userName).Result;
                if (userIdentity != null)
                {
                    var oAuthIdentity = await userIdentity.GenerateUserIdentityAsync(UserManager,
                    Startup.OAuthOptions.AuthenticationType);
                    var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
                    var currentUtc = new SystemClock().UtcNow;
                    ticket.Properties.IssuedUtc = currentUtc;
                    ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(60));
                    string accessToken = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);
                    return Ok(accessToken);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
      
