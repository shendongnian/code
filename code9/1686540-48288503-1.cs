     public string sts = null;
		public EarnPoints (string g)
		{
			InitializeComponent ();
            sts = g;
            GetAccountCountFromMySQL();  
		}
        public void GetAccountCountFromMySQL()
        {
            try
            {
                MySqlConnection sqlconn;
                string connsqlstring = "Server=lightningstorerewards.com;database=sukree_dzgpt;User Id=sukree_gptuser;Password=kgausi9nMNzX;charset=utf8";
                sqlconn = new MySqlConnection(connsqlstring);
                sqlconn.Open();
                string queryString = "SELECT points FROM users WHERE username = @n";
                MySqlCommand sqlcmd = new MySqlCommand(queryString, sqlconn);
                sqlcmd.CommandText = queryString;
                sqlcmd.Parameters.AddWithValue("@n", sts);
