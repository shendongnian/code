	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		private void Border_MouseEnter(object sender, MouseEventArgs e)
		{
			DeviceStatusSnippetPopup.IsOpen = true;
		}
		private void Popup_MouseLeave(object sender, MouseEventArgs e)
		{
			if (!OpenPopupBorder.IsMouseOver)
				DeviceStatusSnippetPopup.IsOpen = false;
		}
		private void Border_MouseLeave(object sender, MouseEventArgs e)
		{
			if (!DeviceStatusSnippetPopup.IsMouseOver)
				DeviceStatusSnippetPopup.IsOpen = false;
		}
	}
