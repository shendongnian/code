    var connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = \\crd-a555-015.occ.local\c$\Users\james.piper\Documents\Visual Studio 2015\Projects\Project V1\Project Database.accdb";
    var query = "INSERT INTO Work_Done (employee,client,project,task,hours) VALUES (@employee,@client,@project,@task,@hours)";
    using (var conn = new OleDbConnection(connectionString))
    {             
        using(var cmd = new OleDbCommand(query, conn))
        {
            // No need to specifiy command type, since CommandType.Text is the default
                
            // I'm assuming, of course, your parameter data types. You should change them if my assumptions are wrong.
            cmd.Parameters.Add("@employee", OleDbType.Integer).Value = user.employee;
            cmd.Parameters.Add("@client", OleDbType.Integer).Value = Convert.ToInt32(listBox1.SelectedItem);
            cmd.Parameters.Add("@project", OleDbType.Integer).Value =  Convert.ToInt32(listBox2.SelectedItem);
            cmd.Parameters.Add("@task", OleDbType.Integer).Value = Convert.ToInt32(listBox3.SelectedItem);
            cmd.Parameters.Add("@hours", OleDbType.Integer).Value = Convert.ToInt32(listBox4.SelectedItem);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"sql insert fail: {ex}");
            }
        }                
    }
