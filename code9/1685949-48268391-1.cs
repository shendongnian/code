    using System.IdentityModel.Tokens;
    using System.Text;
    
    namespace solution.Authentication
    {
      public static class JwtSecurityKey
      {
        public static SymmetricSecurityKey Create(string secret)
        {
          return new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        }
      }
    }
