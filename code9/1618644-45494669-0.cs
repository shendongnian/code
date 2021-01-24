    public bool updateData(){
                _conn.ConnectionString = conn;
                string comando = "";
                try{
                    _conn.Open();
                    comando = "UPDATE Other SET count = 1";
                    //YOUR DB CLIENT COMES HERE
                    MySqlCommand cmd = new MySqlCommand(comando, _conn);
                    cmd.ExecuteNonQuery();
                    _conn.Close();
                    return true;
                }
                catch (Exception ex){
                    ex.Message.ToString();
                    _conn.Close();
                }
                return false;
           
    }
