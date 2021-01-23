	public class UserAuthAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            string token = null;
            IEnumerable<string> tokenHeader;
            if (context.Request.Headers.TryGetValues("Token", out tokenHeader))
                token = tokenHeader.FirstOrDefault();
			
			if (token != null && IsTokenValid(token)
			{
				// user has been authenticated i.e. send us a token we sent back earlier
			}
			else 
			{
				// set ErrorResult - this will result in sending a 401 Unauthorized
				context.ErrorResult = new AuthenticationFailureResult(Invalid token", context.Request);
			}
		}
		
	}
