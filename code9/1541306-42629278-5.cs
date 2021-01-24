    public partial class FuzzyTableControl : UserControl
    {
        public FuzzyTableControl()
        {
            InitializeComponent();
        }
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column = new DataGridTemplateColumn
            {
                CellStyle = new Style(typeof(DataGridCell))
                {
                    Setters =
                    {
                        new Setter(DataGridCell.TagProperty, new Binding(e.PropertyName)),
                    }
                },
                Header = e.Column.Header,
                HeaderStringFormat = e.Column.HeaderStringFormat,
                HeaderStyle = e.Column.HeaderStyle,
                HeaderTemplate = e.Column.HeaderTemplate,
                HeaderTemplateSelector = e.Column.HeaderTemplateSelector,
                // transfer whatever properties you feel worthy in your scenario
                CellTemplate = Resources["FuzzyInnerTableTemplate"] as DataTemplate
            };
        }
    }
    public class FuzzyTableViewModel : BaseViewModel
    {
        public DataTable DataTable { get; set; }
        public FuzzyTableViewModel()
        {
            DataTable = new DataTable();
            DataTable.Columns.Add(new DataColumn("O", typeof(FuzzyInnerTableViewModel)));
            DataTable.Columns.Add(new DataColumn("P", typeof(FuzzyInnerTableViewModel)));
            var c1 = new FuzzyInnerTableViewModel();
            var c2 = new FuzzyInnerTableViewModel();
            c1.DataTable.Rows[1][0] = "Replace";
            var row = new List<object>();
            row.Add(c1);
            row.Add(c2);
            DataTable.Rows.Add(row.ToArray());
        }
    }
