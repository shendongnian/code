        public class LoginUserControl : UserControl, ILoginView
        {
            public LoginUserControl()
            {
                 this.loginPresenter = new LoginPresenter(this, DIContainer.Resolve<IOtherView>());
            }
        }
