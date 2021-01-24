    <ItemsControl ItemsSource="{Binding Roles}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <CheckBox IsChecked="{Binding IsChecked}" Content="{Binding Title}" FontSize="15" />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
----------
    public partial class MainWindow : Window
    {
        private readonly ViewModel _viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
    public class ViewModel
    {
        public ViewModel()
        {
            Roles = RolesController.Instance.SelectAll();
        }
        public List<Role> Roles { get; private set; }
    }
