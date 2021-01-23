	public partial class Splash : Form
	{
		public Splash()
		{
			InitializeComponent();
		}
		private void Splash_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}
		
		private void Splash_OnLoad(object sender, FormClosingEventArgs e)
		{
			await Task.Delay(500);
			
			Loading.Text = "Loading..";
			
			await Task.Delay(3000);
			
			Application.Exit();
		}
	}
