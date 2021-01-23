    public class MyClaimsTransformer : IClaimsTransformer
    {
      private readonly MyDbContext _context;
      public MyClaimsTransformer(MyDbContext context)
      {
        _context = context;
      }
      public Task<ClaimsPrincipal> TransformAsync(ClaimsTransformationContext context)
      {
        var identity = (ClaimsIdentity)context.Principal.Identity;
        var userName = identity.Name;
        var roles = _context.Role.Where(r => r.UserRole.Any(u => u.User.Username == userName)).Select(r => r.Name);
        foreach (var role in roles)
        {
          var claim = new Claim(ClaimTypes.Role, role);
          identity.AddClaim(claim);
        }
        return Task.FromResult(context.Principal);
      }
    }
