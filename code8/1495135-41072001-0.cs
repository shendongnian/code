    public interface IAuthenticationHandlerFactory
    {
        IAuthenticationHandler Create(IUserHandler userHandler);
    }
    public class AuthenticationHandlerFactory : IAuthenticationHandlerFactory
    {
        public IAuthenticationHandler Create(IUserHandler userHandler)
        {
            return new AuthenticationHandler(userHandler);
        }
    }
