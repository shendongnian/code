	public class MyViewModel()
	{
		public ObservableCollection<int> Items { get; set; } = new ObservableCollection<int>();
	}
	private MyViewModel _viewModel = new MyViewModel();
	public MainPage()
	{
		InitializeComponent();
		BindingContext = _viewModel;
	}
	correctButton.Clicked += (sender, e) =>
	{
		App.DB.IncrementScore();
		_viewModel.Items.Add(0);
	};
