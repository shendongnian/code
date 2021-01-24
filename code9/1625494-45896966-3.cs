    public class UserContext : IUserContext {
        private Lazy<IPrincipal> user;
        public UserContext(Func<IPrincipal> valueFactory) {
            this.user = new Lazy<IPrincipal>(valueFactory);
        }
        public int UserId {
            get { return user.Value.Identity.GetUserId<int>(); }
        }
        public string UserName {
            get { return user.Value.Identity.Name; }
        }
    }
