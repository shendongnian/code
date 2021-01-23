    string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\admin\Documents\Book Database.accdb;Persist Security Info=False;";
    // This will be the connection string
    private void Form1_Load(object sender, EventArgs e)
    {
        // Need not to do anything regarding connection
        // some other statements if needed
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
    
        try
        {
            using (OleDbConnection connection = new OleDbConnection(conString)) // Create and initialize connection object
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandText = " Insert into Book Name(Book Name,Book Number,Publisher) values(@BookName,@BookNumber,@Publisher)";
                    command.Parameters.Add("@BookName", OleDbType.VarChar).Value = bookName.Text;
                    command.Parameters.Add("@BookNumber", OleDbType.Integer).Value = bookNumber.Text;
                    command.Parameters.Add("@Publisher", OleDbType.VarChar).Value = publisher.Text;                     
                    command.ExecuteNonQuery();
                    
                }
            }
          MessageBox.Show("Data Saved");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error" + ex);
        }
    
    }
