    public static bool validate_login(string user, string pass)
    {
        Login_Model.connect = DB_Controller.db_connection();
        MySqlCommand cmd = new MySqlCommand(Login_Model.connect);
    }
