     public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
    
                ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);
                
    
                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
                //Insecure message returned, you show to outside world the email exist, 
                //any how here is where you  stop the token generation if email of the useris not confirmed, 
                //going forward if you have speciffic role where this validation is not required 
                //check if user is in that role before checking if user has email confirmed 
                if (!user.EmailConfirmed)
                {
                    context.SetError("invalid_grant", "Email is not confirmed");
                    return;
                }
                //... rest of code
    }
