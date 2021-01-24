    public partial class Page1 : ContentPage, INotifyPropertyChanged
	{
		public static int _player;
		public static int Player
		{
		    get{ return _player; }
		    set{ _player = value; }
		}
		public NewGameH(string homeTeam, string opponentTeam)
		{
			InitializeComponent();
		}
		public void OnPlayerSet(object source, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Begin Player {0} ", Player);
		}
		async void button1_Clicked(object sender, System.EventArgs e)
		{
			var page2 = new Page2();
			page2.PlayerSet += this.OnPlayerSet;
			await Navigation.PushAsync(page2);
		}
    }
