    public partial class Settings : Window
    {
        public static SettingsServicesPhone setCall = new SettingsServicesPhone();
        public Settings()
        {
            InitializeComponent();
            DataContext = this; //<--
        }
        public String SipLoginStatusContent
        {
            get { return setCall.sipLoginStatusContent; }
            set
            {
                if (setCall.sipLoginStatusContent != value)
                {
                    setCall.sipLoginStatusContent = value;
                    OnPropertyChanged("SipLoginStatusContent");  // To notify when the property is changed
                }
            }
        }
        public void applyBtn_Click(object sender, RoutedEventArgs e)
        {
            SipLoginStatusContent = "Logging In";
        }
    }
