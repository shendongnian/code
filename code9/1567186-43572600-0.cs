        private String ConnectionString;
        private SqlConnection connection;
        private String User_ID;
        private String Password;
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader reader;
        public MainWindow()
        {
            InitializeComponent();
           
            ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RFIDdatabase.mdf;Integrated Security=True";
            connection = new SqlConnection(ConnectionString);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine(ID.Text + " and " + Pass.Password);
                cmd.CommandText = "Select * from Login "
                                + "where USER_ID = '" + ID.Text + "' "
                                + "and Password = '" + Pass.Password + "'";
                Console.WriteLine(cmd.CommandText);
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User_ID = Convert.ToString(reader["USER_ID"]);
                    Password = Convert.ToString(reader["Password"]);
                 }
                if (User_ID!= null && Password != null) {
                    if (User_ID.Trim() == ID.Text.Trim()
                       && Password.Trim() == Pass.Password.Trim())
                    {
                    Window1 win = new Window1();
                    win.Show();
                    }
                    else
                    {
                    MessageBox.Show("INCORRECT PASSWORD OR USER ID", "Authentication Failed");
                    }
                }
                else
                {
                    MessageBox.Show("INCORRECT PASSWORD OR USER ID", "Authentication Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Catch Block = " + ex);
            }
            finally {
                connection.Close();
            }
        }
