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
            };
        }
    }
