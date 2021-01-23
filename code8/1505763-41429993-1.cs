    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new JobViewModel();
        }
    }
    <ItemsControl ItemsSource="{Binding Jobs}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <local:JobView />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
