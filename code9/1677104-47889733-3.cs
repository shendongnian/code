    public partial class control : UserControl
    {
        control()
        {
            InitializeComponent();
            InitializeData();
        }
        private InitializeData()
        {
            datagrid.ItemsSource = Core.myObjectPoolList;
            var firstItem = Core.myObjectPoolList.First();
            if (firstItem != null) {
                UpdateDataGridColumns(dataGrid, firstItem.AttributeList, _dynamicColumns);
            }
        }
        private Dictionary<string, DataGridColumn> _dynamicColumns = new Dictionary<string, DataGridColumn>();
        protected void UpdateDataGridColumns(DataGrid dg, List<myAttribute> attributesSample, Dictionary<string, DataGridColumn> existingDynamicColumns)
        {
            foreach (var col in existingDynamicColumns.Values)
            {
                dg.Columns.Remove(col);
            }
            existingDynamicColumns.Clear();
            int idx = 0;
            foreach (var attr in attributesSample)
            {
                var column = new DataGridTextColumn() {
                    Header = attr.Name,
                    Binding = new Binding($"AttributeList[{idx}].Value")
                };
                dg.Columns.Add(column);
                existingDynamicColumns.Add(attr.Name, column);
                ++idx;
            }
        }
    }
