    public class IdentityResolver : IValueResolver<QueryUniqueDto, QueryUnique, UserClaim>
      {
        private IHttpContextAccessor _httpContextAccessor;
    
        public IdentityResolver(IHttpContextAccessor httpContextAccessor) 
        {
          _httpContextAccessor = httpContextAccessor;
        }
    
        public UserClaim Resolve(QueryUniqueDto source, QueryUnique destination, UserClaim destMember, ResolutionContext context)
        {
            return Helper.GetClaimsFromUser(_httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity);
        }
      }
