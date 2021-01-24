    //namespaces   
     public partial class Database_Manager : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public Database_Manager()
        {
            InitializeComponent();
        }
        private void Database_Manager_Load(object sender, EventArgs e)
        {
            labeltitle.Text = "Select the table you want to edit.";
        }
        private void dbupdate()
        {
            try {
                scb = new SqlCommandBuilder(sda);
                sda.Update(dt);
                MessageBox.Show("Update Successful!");
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
            }
        private void buttonupdate_Click(object sender, EventArgs e)
        {
            dbupdate();
        }
