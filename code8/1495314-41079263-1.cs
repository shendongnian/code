    private async void com_start_Click(object sender, EventArgs e)
    {
        string ConString = 
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\MyBrainWash\Englishdb.accdb;";
        using (var Con = new OleDbConnection(ConString))
        {
            Con.Open();
            check_connection.Text = "successed";
            using (var command = new OleDbCommand())
            {
                command.Connection = Con;
                command.CommandText = "Select * From words";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lab_word.Text = reader["word"].ToString();
                        lab_definition.Text = reader["definition"].ToString();
                        await Task.Delay(30000);
                    }
                }
            }
        }
    }
