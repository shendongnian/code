    public class AddResultRow
    {
        public string StationID { get; set; }
        public string Pointnumber { get; set; }
        public string Description { get; set; }
        public string Velocity { get; set; }
        public string Status { get; set; }
    }
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<AddResultRow> _items = new ObservableCollection<AddResultRow>();
        public MainWindow()
        {
            InitializeComponent();
            ResultsDataGrid.ItemsSource = _items;
        }
        private AddResultRow addnewrow()
        {
            return new AddResultRow()
            {
                StationID = "",
                Pointnumber = "",
                Description = "",
                Velocity = "",
                Status = ""
            };
        }
        private void AddResult_Click(object sender, RoutedEventArgs e)
        {
            _items.Add(addnewrow());
        }
        private void RemoveResult_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ResultsDataGrid.SelectedItem as AddResultRow;
            if (selectedItem != null)
            {
                _items.Remove(selectedItem);
            }
        }
    }
