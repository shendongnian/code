    private void button26_Click(object sender, EventArgs e)
    {  
        try
        {
            string cmdText = @"INSERT INTO Main
                              ([Prop], [Value], [Default],[Type])    
                              VALUES('one', 'Kelly', 'Jill','one')";
            using(OleDbConnection connection = new OleDbConnection(.....))
            using(OleDbCommand cmd = new OleDbCommand(cmdText, connection))
            {            
                connection.Open();
                cmd.ExecuteNonQuery();
                button26.Text = "Done Insert"; 
                button26.ForeColor = Color.Lime;
                mainDataGridView.Visible = true;
            }
        }
        catch (Exception ex)
        {
            richTextBox1.Text=("Error "+ex);
            button26.ForeColor = Color.Black;
        }
    }
