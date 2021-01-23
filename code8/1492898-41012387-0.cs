    public partial class MainWindow : Window
    {
        /*mysql
         * 
         * 1. add nuget mysql.data.dll（desktop application）
         * 2. using MySql.Data.MySqlClient;
         * 3. code like bellow , you can try 
         */
        private StringBuilder sb = new StringBuilder();
        public MainWindow()
        {
            InitializeComponent();
            mysql();
            tbx.Text = sb.ToString();
        }
        private void mysql()
        {
            try
            {
                var connstr = "Server=localhost;Uid=root;Pwd=123456;database=world";
                using (var conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from city where countryCode= @ID";
                        cmd.Parameters.AddWithValue("@ID", "100");
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var ii = reader.FieldCount;
                                for (int i = 0; i < ii; i++)
                                {
                                    if (reader[i] is DBNull)
                                        sb.AppendLine("null");
                                    else
                                        sb.AppendLine(reader[i].ToString());
                                }
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
