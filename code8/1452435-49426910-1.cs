	public class MyPage : ContentPage
	{
		MyModalPage _myModalPage;
		
		public MyPage()
		{
			InitializeComponent();
			// ... set up the page ...
		}
		
		private async void ShowModalPage()
		{
            // When you want to show the modal page, just call this method
			// add the event handler for to listen for the modal popping event:
			MyProject.App.Current.ModalPopping += HandleModalPopping;
			_myModalPage = new MyModalPage();
			await MyProject.App.Current.MainPage.Navigation.PushModalAsync(_myModalPage());
		}
		
		private void HandleModalPopping(object sender, ModalPoppingEventArgs e)
		{
			if (e.Modal == _myModalPage)
			{
				// now we can retrieve that phone number:
				var phoneNumber = _myModalPage.Data;
				_myModalPage = null;
				
				// remember to remove the event handler:
				MyProject.App.Current.ModalPopping -= HandleModalPopping;
			}
		}
		
	}
	
