    using MySql.Data.MySqlClient;
    namespace WinformFiddle
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = "server=myserver.mydomain.edu;user id=MyUserWithAccessUsername;password=MyUserWithAccessPassword;persistsecurityinfo=True;database=roomscheduling;Integrated Security=False";
                conn.Open();
                MySqlCommand selCmd = new MySqlCommand("SELECT ...", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(selCmd);
                ....
