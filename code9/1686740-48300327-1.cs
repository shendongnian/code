    public partial class thirdPage : ContentPage
	{
		public thirdPage ()
		{
			InitializeComponent ();
            main.Clicked += Main_Clicked;
		}
        private void Main_Clicked(object sender, EventArgs e)
        {
            App.NavPage.PopToRootAsync(true);
        }
    }
