    public partial class Form1 : Form
    {
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("col1", typeof(int)));
            dt.Columns.Add(new DataColumn("col2", typeof(int)));
            dt.Columns.Add(new DataColumn("col3", typeof(int), "col2 - col1"));
            var newRow = dt.NewRow();
            newRow[0] = 5;
            newRow[1] = 7;
            dt.Rows.Add(newRow);
            newRow = dt.NewRow();
            newRow[0] = 12;
            newRow[1] = 19;
            dt.Rows.Add(newRow);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dt.Rows[0][0] = 10;
        }
    }
