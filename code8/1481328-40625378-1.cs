    public partial class MainWindow : IViewFor<MainViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel), typeof(MainViewModel), typeof(MainWindow));
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            this.OneWayBind(ViewModel, x => x.Items, x => x.ListView.ItemsSource);
            this.OneWayBind(ViewModel, x => x.IsLoading, x => x.ProgressRing.IsActive);
            this.Events().Loaded.Subscribe(_ => this.ViewModel.Load.Execute().Subscribe());
        }
        public MainViewModel ViewModel
        {
            get { return (MainViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MainViewModel)value; }
        }
    }
    <Window x:Class="ProgressRing.MainWindow"
                      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                      xmlns:controls="http://metro.mahapps.com/winfx/xaml/controls"
                      Title="MainWindow">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
        <ScrollViewer Grid.Row="0">
            <ListView x:Name="ListView" ItemStringFormat="Item {0}" />
        </ScrollViewer>
        <controls:ProgressRing x:Name="ProgressRing" Grid.Row="1" />
    </Grid>
