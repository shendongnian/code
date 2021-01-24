     SqlConnection conexion;
     private void save() {
        conexion = cConexion.getConexion(); 
        
        SqlCommand comand = new SqlCommand();
        comand.Connection = conexion;
        comand.CommandText = "INSERT INTO Book(Id, title, author) VALUES(@Id, @title, @author)";
        comand.Parameters.Add("Id", SqlDbType.Int, 3).Value = this.idtxtbox.Text;
        comand.Parameters.Add("title", SqlDbType.NChar).Value = this.titletxtbox.Text;
        comand.Parameters.Add("author", SqlDbType.NChar).Value = this.authortxtbox.Text;
        comand.ExecuteNonQuery();
        clear();
     }
    
