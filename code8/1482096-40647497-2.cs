    public partial class LoginPage : ContentPage {
        public LoginPage() {
			InitializeComponent();
		}
        protected override async void OnAppearing() {
            await Check(/* Add code here to get your GoogleProfile object */);
        }
        public async Task Check(GoogleProfile googleprofile) {
            var ID = googleprofile.Id;
            if (string.IsNullOrEmpty(ID)) {
                return;
            } else {
                await Navigation.PushAsync(new Home());
            }
        }
    }
