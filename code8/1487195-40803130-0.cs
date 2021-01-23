    private void Form1_Load(object sender, EventArgs e)
    {
        var conn = new DBConnect().Connect();
        if (conn.State == ConnectionState.Open)
        {
            StatusTextLabel.Text = "Connected";
        }
    }
    public class DBConnect
    {
        public SqlConnection Connect()
        {
            SqlConnection conn = ...
            // ...
            return conn;
        }
    }
