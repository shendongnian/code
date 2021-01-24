    <Grid Background="Transparent" MouseEnter="Grid_MouseEnter">
        <Grid.Style>
            <Style TargetType="{x:Type Grid}">
                <!-- normal binding, this line is comment and should be gray -->
                <Setter Property="ToolTip" Value="{Binding StoredValue}" />
            </Style>
        </Grid.Style>
    </Grid>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string StoredValue => "123"; // is called every time mouse is entered
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        // rise notification manually
        void Grid_MouseEnter(object sender, MouseEventArgs e) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StoredValue)));
    }
