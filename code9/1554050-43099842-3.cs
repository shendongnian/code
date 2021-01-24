    public partial class LoginView : Grid
    {
        public static readonly BindableProperty UserNameProperty =
            BindableProperty.Create(nameof(UserName), typeof(string), typeof(LoginView), string.Empty);
        public static readonly BindableProperty PasswordProperty =
            BindableProperty.Create(nameof(Password), typeof(string), typeof(LoginView), string.Empty);
        public static readonly BindableProperty LoginCommandProperty =
            BindableProperty.Create(nameof(LoginCommand), typeof(ICommand), typeof(LoginView), null);
        public LoginView()
        {
            InitializeComponent();
        }
        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty,value); }
        }
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public ICommand LoginCommand
        {
            get { return (ICommand)GetValue(LoginCommandProperty); }
            set { SetValue(LoginCommandProperty, value); }
        }
    }
