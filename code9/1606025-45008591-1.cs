    using (OleDbCommand projects = new OleDbCommand("SELECT * FROM Client_projects WHERE clients = ? AND Date = ?", conn))
    {
        projects.Parameters.Add("?", OleDbType.VarChar).Value = listBox1.SelectedItem.ToString();
        projects.Parameters.Add("?", OleDbType.Date).Value = DateTime.Today;
        OleDbDataReader project = projects.ExecuteReader();
        while (project.Read())
        {
            listBox2.Items.Add(project[1].ToString());
        }
    }
