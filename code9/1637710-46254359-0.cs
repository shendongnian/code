    public partial class Form1 : Form
    {
        DataGridView dataGridView;
        DataTable dataTable;
        DataView dataView;
        TextBox textBoxSearch;
        public Form1()
        {
            //InitializeComponent();
            Width = 400;
            dataGridView = new DataGridView { Parent = this, Dock = DockStyle.Top };
            textBoxSearch = new TextBox { Parent = this, Top = 200 };
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("BirthDate", typeof(DateTime));
            dataTable.Rows.Add(1, "Bob", new DateTime(2001, 01, 01));
            dataTable.Rows.Add(2, "John", new DateTime(1999, 09, 09));
            dataTable.Rows.Add(3, "Alice", new DateTime(2002, 02, 02));
            dataView = new DataView(dataTable);
            dataGridView.DataSource = dataView;
        }
        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            var text = textBoxSearch.Text;
            var values = dataTable.Columns
                .OfType<DataColumn>()
                .Select(c => "Convert([" + c.ColumnName + "], System.String)")
                .Select(c => c + " like '%" + text + "%' ");
            var filter = string.Join(" or ", values);
            dataView.RowFilter = filter;
        }
    }
