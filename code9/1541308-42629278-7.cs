    public partial class FuzzyInnerTableControl : UserControl
    {
        public FuzzyInnerTableControl()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
            {
                DataContext = Resources["defaultVM"];
            }
        }
    }
    public class FuzzyInnerTableViewModel : BaseViewModel
    {
        public DataTable DataTable { get; private set; }
        public FuzzyInnerTableViewModel()
        {
            DataTable = new DataTable();
            DataTable.Columns.Add(new DataColumn("A"));
            DataTable.Columns.Add(new DataColumn("B"));
            for (int rowId = 0; rowId < 3; rowId++)
            {
                var row = new List<object>();
                row.Add(rowId);
                row.Add(2 * rowId);
                DataTable.Rows.Add(row.ToArray());
            }
        }
    }
