    public partial class LoginPage : ContentPage {
        public LoginPage() {
			InitializeComponent();
		}
        protected override async void OnAppearing() {
            await Check();
        }
        public async Task Check(object sender, EventArgs e, GoogleProfile googleprofile) {
            var ID = googleprofile.Id;
            if (string.IsNullOrEmpty(ID)) {
                return;
            } else {
                await Navigation.PushAsync(new Home());
            }
        }
    }
