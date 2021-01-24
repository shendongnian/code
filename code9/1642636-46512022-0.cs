    public interface ISecurityService
    {
        SignInStatus SignIn(string email, string password, bool isPersistent);
        void SignOut();
    }
