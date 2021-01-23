      services.AddAuthorization(async options =>
                {
                    var ClaimList = await claimApplication.GetList(applicationClaim);
                    foreach (var item in ClaimList)
                    {                        
                        options.AddPolicy(item.ClaimCode, policy => policy.RequireClaim(item.ClaimCode));                       
                    }
                });
