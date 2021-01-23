	public class MyModalPage : ContentPage
	{
		public string Data { get; set; }
		
		public MyModalPage()
		{
			InitializeComponent();
			// ... set up the page ...
		}
		
		private async void PopThisPage()
		{
            // When you want to pop the page, just call this method
			// Perhaps you have a text view with x:Name="PhoneNumber", for example
			Data = PhoneNumber.Text; // store the "return value" before popping
			await MyProject.App.Current.MainPage.Navigation.PopModalAsync();
		}
	}
