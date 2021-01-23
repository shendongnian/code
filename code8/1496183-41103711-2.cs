	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			vm.ReadFile();
		}
	}
