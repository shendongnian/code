    private class MockHttpContext : HttpContextBase {
        private readonly IPrincipal user;
        public MockHttpContext(IPrincipal principal) {
            this.user = principal;
        }
        public override IPrincipal User {
            get {
                return user;
            }
            set {
                base.User = value;
            }
        }
    }
