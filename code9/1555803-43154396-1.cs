    public partial class Form1 : Form
    {
        DataTable dt;
    
        public Form1()
        {
            InitializeComponent();
    
            InitDataGridView();
        }
        private void InitDataGridView()
        {
            dt = new DataTable();
            dt.Columns.Add("A"); dt.Columns.Add("B");
            var dr = dt.NewRow();
            dr["A"] = "A-init"; dr["B"] = "B-init";
            dt.Rows.Add(dr);
            dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var dr = dt.NewRow();
            var counter = dt.Rows.Count;
            dr["A"] = "A-" + counter; dr["B"] = "B-" + counter;
            dt.Rows.Add(dr);
        }
    }
