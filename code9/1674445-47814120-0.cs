    using MySql.Data.MySqlClient;
    namespace Project
    {
    public sealed partial class MainPage : Page
    {
        const string connString = "server=server_name;user id=uid;pwd=password;persistsecurityinfo=True;database=db_name";
        public MainPage()
        {
            this.InitializeComponent();
        }
        private bool DataValidation(string user, string pass)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            using (MySqlCommand cmd = new MySqlCommand("SELECT " +
                "Username, Password " +
                "FROM users " +
                "WHERE Username=@user AND Password=@pass;", conn))
            {
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Connection = conn;
                cmd.Connection.Open();
                MySqlDataReader login = cmd.ExecuteReader();
                if (login.Read())
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string user = UserTextBox.Text;
            string pass = PassBox.Password;
            if (user == "" || pass == "")
            {
                StatusTextBlock.Text = ("Your text");
                return;
            }
            bool loginSuccessful = DataValidation(user, pass);
            if (loginSuccessful)
            {
                this.Frame.Navigate(typeof(Page2), null);
            }
            else
            {
                StatusTextBlock.Text = "Your text";
            }
        }
    }
    }
