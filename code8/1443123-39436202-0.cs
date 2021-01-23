    using System.Security.Claims;
    using System.Security.Principle.IPrinciple;
    public static class UserClaimExtentions {
      public static string GivenName(this IPrinciple user) {
        return user.GetClaimValue(ClaimTypes.GivenName);
      }
      public static string NameIdentifier(this IPrinciple user) {
        return user.GetClaimValue(ClaimTypes.NameIdentifier);
      }
      public static string GetClaimValue(this IPrinciple user, string name) {
         var claimsIdentity = user.Identity as ClaimsIdentity;
         return claimsIdentity?.FindFirst(name)?.Value;
      }
      //If you aren't using the new operators from Roslyn for null checks then
      //use this method instead
      public static string GetClaimValue(this IPrinciple user, string name) {
         var claimsIdentity = user.Identity as ClaimsIdentity;
         var claim = claimsIdentity == null ? null : claimsIdentity?.FindFirst(name);
         return claim == null ? null : claim.Value;
      }
    }
