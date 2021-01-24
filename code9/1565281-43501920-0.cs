	public class MyPage6 : ContentPage
	{
		ActivityIndicator _ac = new ActivityIndicator { IsVisible = false, IsRunning = false };
		public MyPage6()
		{
			Button b = new Button {Text = "Press for ActivityIndicator" };
			b.Clicked += B_Clicked;
			Content = new StackLayout
			{
				Children = {
					_ac,
					b,
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
		async void B_Clicked(object sender, EventArgs e)
		{
			_ac.IsRunning = true;
			_ac.IsVisible = true;
			await Task.Delay(2000);
			_ac.IsRunning = false;
			_ac.IsVisible = false;
		}
	}
