    public class AppUser : ClaimsPrincipal {
        public AppUser(ClaimsPrincipal principal)
            : base(principal) {
        }
        public string Name {
            get {
                return this.FindFirst("UserName")?.Value;
            }
        }
        public string CompanyType {
            get {
                return this.FindFirst("CompanyType")?.Value;
            }
        }
    }
