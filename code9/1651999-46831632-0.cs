    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            DataGridView dataGridView;
            DataTable dataTable;
            DataView dataView;
            TextBox textBoxSearch;
            public Form1()
            {
                //InitializeComponent();
                Width = 800;
                dataGridView = new DataGridView { Parent = this, Dock = DockStyle.Top };
                textBoxSearch = new TextBox { Parent = this, Top = 200 };
                textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
                dataTable = new DataTable();
                dataTable.Columns.Add("Name");
                dataTable.Columns.Add("Country");
                dataTable.Columns.Add("City");
                dataTable.Rows.Add("JAck", "Country1", "City1");
                dataTable.Rows.Add("Name2", "Country1", "City2");
                dataTable.Rows.Add("JACK", "Country2", "City1");
                dataView = new DataView(dataTable);
                dataGridView.DataSource = dataView;
            }
            private void TextBoxSearch_TextChanged(object sender, EventArgs e)
            {
                var words = textBoxSearch.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (!words.Any())
                {
                    dataGridView.DataSource = dataView;
                    return;
                }
                var dv = dataView;
                foreach (var word in words)
                {
                    var values = dataTable.Columns
                        .OfType<DataColumn>()
                        .Select(c => "Convert([" + c.ColumnName + "], System.String)")
                        .Select(c => c + " like '%" + word + "%'");
                    var filter = string.Join(" or ", values);
                    dv = new DataView(dv.ToTable());
                    dv.RowFilter = filter;
                    dataGridView.DataSource = dv;
                }
            }
        }
    }
