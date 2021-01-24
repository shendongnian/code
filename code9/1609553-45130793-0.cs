    public partial class MainWindow : Window
    {
        public ViewModel Vm { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            Vm = new ViewModel();
            Vm.Items = new ObservableCollection<ExpandoObject>();
            DataContext = Vm;
            var fieldName = "FirstName";
            var item = new ExpandoObject() as IDictionary<string, Object>;
            item.Add(fieldName, "Adam"); // Dynamically adding new fields
            var eoItem = item as ExpandoObject;
            Vm.Items.Add(eoItem);
            // Dynamically adding new columns
            var col = new DataGridTextColumn();
            col.Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            col.Header = fieldName;
            col.Binding = new Binding(fieldName) { Mode = BindingMode.TwoWay };
            MyGrid.Columns.Add(col);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
    public class ViewModel
    {
        public ObservableCollection<ExpandoObject> Items { get; set; }
    }
