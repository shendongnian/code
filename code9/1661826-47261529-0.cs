    public class ClaimsTransformationModule : ClaimsAuthenticationManager {  
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal) {  
            if (incomingPrincipal != null && incomingPrincipal.Identity.IsAuthenticated == true) {  
               var identity = (ClaimsIdentity)incomingPrincipal.Identity;
               var user = GetUserData(identity);
               identity.AddClaim(new Claim("fullname", user.GetFullName(user.UserName)));  
               identity.AddClaim(new Claim("avatarUrl", user.AvatarUrl)); 
            }  
    
            return incomingPrincipal;  
        }  
    } 
