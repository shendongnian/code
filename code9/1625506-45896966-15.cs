    public interface IUserContextFactory {
        IUserContext Create(IPrincipal user);
    }
    public class UserContextFactory {
        public IUserContext Create(IPrincipal user) {
             return new UserContext(user);
        }
    }
