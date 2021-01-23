    //put this on top under "public partial class"
        private string conn;
        MySqlConnection connect;
    //make a private void which connects to database
    
     private void db_connection()
        {
            try
            {
                conn = "Server=127.0.0.1;Database=locadora;Uid=root;Pwd=;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            
            catch (MySqlException e)
            {
                throw;
            }
            finally
            {
                MessageBox.Show("No connection!");
            }
         //Make private bool with MySql code
    
         private bool Read_Value()
        {
            db_connection();
            MySqlCommand cmdRead = new MySqlCommand(string _client);
             //I just used your code. If not right, edit
    
            cmdRead.CommandText = "SELECT cliente_codigo FROM cliente WHERE cliente_codigo =@_cliente_codigo AND cliente_nome LIKE '%" + txt_nomepesquisa.Text"%'";
            cmdRead.Parameters.AddWithValue("@_cliente_codigo" _client);
            cmdRead.Connection = connect;
            MySqlDataReader dbRead= cmdRead.ExecuteReader();
            if (dbRead.Read())
            {
                lbl_cliente_codigo.Text = dbRead.GetString(0);
                connect.Close();
                return true;
            }
            else
            {
                connect.Close();
                return false;
            }
        }
    //use it in, lets say button click
    //(put in button event)
    string _client = lbl_cliente_codigo.text;
    try
    {
      bool c = Read_Value(_client);
      if(c)
      { 
         lbl_cliente_codigo.text = _client;
      }
    }
    
    catch
    {
      MessageBox.Show("No connection!");
    }
