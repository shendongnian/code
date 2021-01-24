        public class AboutController : BaseController
        {
             private readonly IAboutService _aboutService;
             public AboutController (IAboutService aboutService, ISomeService someService)  : base(someService)
             {
                 _aboutService = aboutService;
             }
        }
