    //Collection for the datagrid
    public ObservableCollection<InfoField> infoFieldData;
    public MainWindow()
    {
        InitializeComponent();
        infoFieldData = new ObservableCollection<InfoField>();
        InfoField info1 = new InfoField();
        InfoField info2 = new InfoField();
        infoFieldData.Add(info1);
        infoFieldData.Add(info2);
        dataGrid.ItemsSource = infoFieldData;
        dataGrid.Items.Refresh();
    }
    
    public class InfoField
    {
        public bool ShowRpm { get; set; }
        public bool ShowCurrent { get; set; }
        public bool ShowTemperature { get; set; }
        public Direction Direction { get; set; }
    }
    public enum Direction
    {
        Horizontal,
        Vertical
    }
