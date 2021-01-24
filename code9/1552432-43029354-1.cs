	public partial class MainForm : Form
	{
		public MainForm()
		{
			Lazy<TwitterCommunicator> _lazyTwitter = new Lazy<TwitterCommunicator>();
		}
	}
	public void SomeTwitterPanelMethod()
	{
		_lazyTwitter.Value.LoadTweets();
	}
