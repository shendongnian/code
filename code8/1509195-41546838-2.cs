    public MainWindow()
    {
        InitializeComponent();
        DataContext = new ViewModel();
    }
----------
    <DataGrid AutoGenerateColumns="False" 
      Name="dataGrid1" 
      CanUserAddRows="False" CanUserSortColumns="False" CanUserResizeColumns="True" CanUserReorderColumns="False" 
      ItemsSource="{Binding TheDataObjects}">
        <DataGrid.Columns >
            <DataGridCheckBoxColumn Header = "" Binding="{Binding Check, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" MinWidth="50" />
            <DataGridTextColumn Header = "User" Binding="{Binding User, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" MinWidth="50" />
        </DataGrid.Columns>
    </DataGrid>
