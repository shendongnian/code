    public partial class launcher5Page : ContentPage {
		public launcher5Page() {
			InitializeComponent();
			webview1.Source = "web address here";
            /* Normally you want to subscribe in OnAppearing and unsubscribe in OnDisappearing but since another page would call this, we need to stay subscribed */
            MessagingCenter.Unsubscribe<string>(this, "ChangeWebViewKey");
            MessagingCenter.Subscribe<string>(this, "ChangeWebViewKey", newWebViewUrl => Device.BeginInvokeOnMainThread(async () => {
                webview1.Source = newWebViewUrl;
            }));
		}
	}
