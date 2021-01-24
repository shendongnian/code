      public static class ExtensionMethods
    {
        public static string getUserId(this ClaimsPrincipal user) {
            if (!user.Identity.IsAuthenticated)
                return null;
 
            ClaimsPrincipal currentUser = user;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
