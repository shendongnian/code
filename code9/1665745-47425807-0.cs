    public bool loginFromMySQL()
    {
        MySqlConnection sqlconn=null;
        bool loginSuccess=false;
        try
        {
            string connsqlstring = "Server=serverAddress;Port=3306;database=database Name;User Id=userName;Password=user password;charset=utf8";
            sqlconn = new MySqlConnection(connsqlstring);
            sqlconn.Open();
            DataSet tickets = new DataSet();
            string userName = "userName";
            string password = "password";
            string queryString = "select * from  login where userName='" + userName + "' and password='" + password + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, sqlconn);
            adapter.Fill(tickets, "login");
            if (tickets.Tables["login"].Rows.Count > 0)
            {
                //login success
                loginSuccess=true;
            }
            else
            {
                    loginSuccess=false;
            }
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
        }
        sqlconn.Close();
        return loginSuccess;
    }
