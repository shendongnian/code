	public partial class App : Application
	{
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
			ControlWindow NewWindowB = new ControlWindow();
			NewWindowB.Show();
		}
	}
