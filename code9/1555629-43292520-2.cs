    <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Rows}">
      <DataGrid.Columns>
        <DataGridTextColumn Binding="{Binding Amount}"/>
        <DataGridComboBoxColumn SelectedItemBinding="{Binding Fee, UpdateSourceTrigger=PropertyChanged}"
                                ItemsSource="{x:Static local:FeeType.List}"
                                DisplayMemberPath="Name"
                                Width="200"/>
      </DataGrid.Columns>
    </DataGrid>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Rows = new List<RowViewModel>
            {
                new RowViewModel(),
                new RowViewModel(),
            };
            DataContext = this;
        }
        public List<RowViewModel> Rows { get; } 
    }
