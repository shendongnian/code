    public partial class Form1 : Form
    {
      
        SqlConnection con;
        private string CS_1 = @"Data Source=99.88.88.156,33400\SQLMINFOR;Initial Catalog=Minfor;Integrated Security=False;Password=****;User ID=sa;";
        private string CS_2 = @"Data Source=BACKUP-MIN\SQLMIN;Initial Catalog=Minfor;Integrated Security=False;Password=****;User ID=sa;";
        public string check_Active_Connection_String()
        {
            string main_CS = "";
            if (try_CS(CS_1))
            {
                main_CS = CS_1;
            }
            else if (try_CS(CS_2))
            {
                main_CS = CS_2;
            }
            return main_CS;// use main_CS for your connection string further
        }
        private bool try_CS(string CS)
        {
            try
            {
                using (con = new SqlConnection(CS))
                {
                    con.Open();
                    return true;
                }
            }
            catch (Exception exp)
            {
                return false;
            }
        }
        public Form1()
            
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            try
            {
                con.Open();
                
                SqlCommand r = new SqlCommand("SELECT Login FROM Users WHERE Login not like '%Wszyscy%'", con);
                SqlDataReader dr = r.ExecuteReader(); 
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["Login"]);
                }
                dr.Close();
                dr.Dispose();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            
        }
