    var user = Users.SingleOrDefault(x => x.Subject == context.Subject.GetSubjectId());
                if (user != null)
                {
                        try
                        {
                           //add subject as claim
                            var claims = new List<Claim>
                            {
                             new Claim(Constants.ClaimTypes.Subject, user.Subject),
                            };
                            //get username
                            UserClaim un = new UserClaim
                            {
                                Subject = Guid.NewGuid().ToString(),
                                ClaimType = "username",
                                ClaimValue = string.IsNullOrWhiteSpace(user.UserName) ?  "unauth" : user.UserName
                            };
                            claims.Add(new Claim(un.ClaimType, un.ClaimValue));
                            //get email
                            UserClaim uem = new UserClaim
                            {
                                Subject = Guid.NewGuid().ToString(),
                                ClaimType = "email",
                                ClaimValue = string.IsNullOrWhiteSpace(user.EmailAddress) ? string.Empty : user.EmailAddress
                            };
       context.IssuedClaims = claims;
                                              
                        }
                        catch (Exception ex)
                        {
    
                            string msg = $"<-- Error Getting Profile: Message: {ex.Message}, Inner Exception:{ex.InnerException} --->";
                            myLogger log = new myLogger("IdentityServer");
                        }
     
                }
                //return Task.FromResult(context.IssuedClaims);
                return Task.FromResult(0);
    
