    namespace YourNameSpace.View
    {
        public partial class LoginView : ViewBase<LoginViewModel>
        {
            public LoginView(LoginViewModel viewModel)
                : base(viewModel)
            {
                InitializeComponent();
            }
        }
    }
