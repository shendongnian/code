    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {
 
        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:client_id"];
 
            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }
 
            var refreshTokenId = Guid.NewGuid().ToString("n");
 
            using (AuthRepository _repo = new AuthRepository())
            {
                var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime"); 
               
                var token = new RefreshToken() 
                { 
                    Id = Helper.GetHash(refreshTokenId),
                    ClientId = clientid, 
                    Subject = context.Ticket.Identity.Name,
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime)) 
                };
 
                context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
                context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;
                
                token.ProtectedTicket = context.SerializeTicket();
 
                var result = await _repo.AddRefreshToken(token);
 
                if (result)
                {
                    context.SetToken(refreshTokenId);
                }
             
            }
        }
 
