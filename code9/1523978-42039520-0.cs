    public partial class PasswordUserControl : UserControl
    {
        public SecureString Password
        {
            get { return (SecureString)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(SecureString), typeof(PasswordUserControl),
                new PropertyMetadata(default(SecureString), new PropertyChangedCallback(OnPasswordChanged)));
        public PasswordUserControl()
        {
            InitializeComponent();
            PasswordEntryBox.PasswordChanged += PasswordEntryBox_PasswordChanged;
        }
        private bool _handleEvent = true;
        private void PasswordEntryBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
           if(_handleEvent)
                Password = ((PasswordBox)sender).SecurePassword;
        }
        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SecureString ss = e.NewValue as SecureString;
            if(ss != null)
            {
                PasswordUserControl control = d as PasswordUserControl;
                if(control != null)
                {
                    control._handleEvent = false;
                    control.PasswordEntryBox.Password = ConvertToUnsecureString(ss);
                    control._handleEvent = true;
                }
            }
        }
        public static string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
