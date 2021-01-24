    private void button1_Click(object sender, EventArgs e)
    {
        using(var command = new SqlCommand(
                 "insert into [Table] (word, synonym) values (@word,@syn)",
                  new SqlConnection(conn)
              ))
        {
           command.Connection.Open();//Since we aren't reopening an old connection, errors are less likely.    
           command.CommandType = CommandType.Text;
           command.Parameters.AddWithValue("@word", wordbox.Text); 
           command.Parameters.AddWithValue("@syn", synonymbox.Text);                   
                       
           if(command.ExecuteNonQuery() > 0 )
               MessageBox.Show("Word and Synonym added!");
        }
    }
