    public partial class AddDriver : Window
    {
        MySqlConnection connection = new MySqlConnection();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DatabaseController db = new DatabaseController();
        public static string qnum;
        public AddDriver()
        {
            InitializeComponent();
        }
        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }
        public DataTable driver(string query)
        {
            DataTable dtable = new DataTable();
            try
            {
                OpenDbase(query);
                adapter.Fill(dtable);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtable;
        }
        private void OpenDbase(string query)
        {
            try
            {
                string connectionstring = "server=sql12.freemysqlhosting.net; port=3306; user id=sql12192362; password= DtxpressProject25!; persistsecurityinfo=False;database=sql12192362";
                connection = new MySqlConnection(connectionstring);
                adapter.SelectCommand = new MySqlCommand(query, connection);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(adapter);
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void qrcode_Click(object sender, RoutedEventArgs e)
        {
            string fn = fnum.Text;
            int count = driver("Select * from driver where FranchiseNumber ='" + fn + "'").DefaultView.Count;
            if (count > 0)
            {
                MessageBox.Show("'"+fn+"' is already on the list");
            }
            else
            {
                OpenDbase("Insert into driver (LastName, FirstName,MidInitial,Address,Contact,FranchiseNumber,LicenseNumber,Income, Password) values ('" + this.lname.Text + "','" + this.fname.Text + "','" + this.midint.Text + "','" + this.addrss.Text + "','" + this.contact.Text + "','" + this.fnum.Text + "','" + this.lnum.Text + "', '0', '" + this.fnum.Text + "')");
                DataTable dtable = new DataTable();
                adapter.Fill(dtable);
                connection.Close();
            }
            QRCode qr = new QRCode();
            qr.Show();
            this.Hide();
            qnum = driver("Select LicenseNumber from driver where FranchiseNumber = '"+fn+"'").ToString();
           // qnum = "hello";
        }
    }
