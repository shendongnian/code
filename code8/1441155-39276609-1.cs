        class MainWindow : Form
        {
        private MySqlDataAdapter adapter;
        private MySqlCommandBuilder cmd;
        private BindingSource bs = new BindingSource();
        private DataGridView dataGridView1;
        private DataTable dt = new DataTable();
        String sql = "SELECT * FROM grupe_artikala";
        // Constructor
        public MainWindow()
        {
            this.InitializeComponent();
        }
        // Get data
        public void GetData(string sql)
        {        
            using (var conn = new MySqlConnection(Properties.Settings.Default.connString))
            {
                try
                {
                    conn.Open();
                    adapter = new MySqlDataAdapter(sql, conn);
                    cmd = new MySqlCommandBuilder(adapter);
                    adapter.Fill(dt);
                    bs.DataSource = dt;                           
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }           
        }
    
        // Load
        private void MainWindow_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bs;
            GetData(sql);
        }
    
       // Reload click
        private void reload_Click(object sender, EventArgs e)
        {
            GetData(sql);
        }
    }
