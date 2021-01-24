    using System.Data.SqlClient;
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
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = "server=myserver.mydomain.edu;user id=MyUserWithAccessUsername;password=MyUserWithAccessPassword;persistsecurityinfo=True;database=roomscheduling;Integrated Security=False";
                conn.Open();
                SqlCommand selCmd = new SqlCommand("SELECT ...", conn);
                SqlDataAdapter da = new SqlDataAdapter(selCmd);
                ....
