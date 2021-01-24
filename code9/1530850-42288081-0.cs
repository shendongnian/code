        public partial class LoginPage : ContentPage
        {
            
            public LoginPage()
            {
                InitializeComponent();
                
            }
            
            
            async void LoginBtnClicked(object sender, EventArgs args)
            {
                await Navigation.PushModalAsync(new AuthenicationBrowser());
            }
    
            public async void PopModal()
            {
                
                Debug.WriteLine("Navigation.ModalStack  PopModal ===> {0}", App.Current.MainPage.Navigation.ModalStack.Count);
                await App.Current.MainPage.Navigation.PopModalAsync();
    
            }
           
    
    
        }
