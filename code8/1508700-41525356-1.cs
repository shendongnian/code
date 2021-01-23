    public class RoleClaimAuthorizeAttribute : AuthorizeAttribute
    {
        public RoleClaim RoleClaim { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            foreach (var claims in GetClaims(User.Identity as ClaimsIdentity))
            {
                if (RoleClaim & claims > 0)
                {
                    return true;
                } 
            }
            return false;
        }
        private IEnumerable<RoleClaim> GetClaims(ClaimsIdentity ident)
        {
            return ident==null
                ? Enumerable.Empty<RoleClaim>()
                : ident.Claims.Where(c=>c.Type=="RoleClaims")
                    .Select(c=>(RoleClaim)Enum.Parse(typeof(RoleClaim), String.Join(",", c.Value))); 
        }
    }
    
