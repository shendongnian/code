    public class SignIn : ContentPage
    {
        public SignIn(){
           InitializeComponent();
           // Note the VM constructor takes now a INavigation parameter
           BindingContext = new LocalAccountViewModel(Navigation);
        }
    }
