    public interface ICurrentUser
    {
        int UserId { get; }
    }
    public class AspNetCurrentUser : ICurrentUser
    {
        public int UserId { get { return HttpContext.Current.User.GetUserId<int>(); } }
    }
    public class Service : IService
    {
        private readonly ICurrentUser _currentUser;
    
        public Service(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public object WorkWithUserId()
        {
            return _currentUser.UserId;
        }
    }
