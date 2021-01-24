    <Window>
        <Window.Resources>
            <ResourceDictionary>
                <Style x:Key="DataGridRowStyle" TargetType="DataGridRow">
                    <Setter Property="Background" Value="{Binding RowBackground}"/>
                </Style>
            </ResourceDictionary>
        </Window.Resources>
        <DataGrid ItemsSource="{Binding Records}" RowStyle="{StaticResource DataGridRowStyle}" AutoGenerateColumns="False" CanUserAddRows="False">        
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Value}" Width="*"/>
            </DataGrid.Columns>
        </DataGrid>    
    </Window>
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel(); 
    }
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Records.Add(new RecordViewModel()
            {
                Value = "Red",
                RowBackground = new SolidColorBrush(Colors.LightCoral)
            });
        
            Records.Add(new RecordViewModel()
            {
                Value = "Green",
                RowBackground = new SolidColorBrush(Colors.LightGreen)
            });
        
            Records.Add(new RecordViewModel()
            {
                Value = "Blue",
                RowBackground = new SolidColorBrush(Colors.LightBlue)
            });
        
            Records[2].Value = "Not blue anymore";
            Records[2].RowBackground = new SolidColorBrush(Colors.LightPink);
        }
        
        public ObservableCollection<RecordViewModel> Records { get; } = new ObservableCollection<RecordViewModel>();
    }
    public class RecordViewModel : INotifyPropertyChanged
    {
        private string _value;
        private Brush _rowBG;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        public Brush RowBackground
        {
            get
            {
                return _rowBG;
            }
            set
            {
                _rowBG = value;
                OnPropertyChanged(nameof(RowBackground));
            }
        }
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
