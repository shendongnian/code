    public class UserController : Controller
        {
            private readonly ILogin    _login;
            private readonly IRegister _registration;
    
            public UserController(ILogin login, IRegister registration)
            {
                _login = login;
                _registration = registration;
            }
    ...
    ...
    }
