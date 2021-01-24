    con.Open();
    SqlCommand command = new SqlCommand("SELECT name from inventorymaster ", con);
    SqlDataReader read = command.ExecuteReader();
    foreach (Control c in MainDownPanel.Controls)
    {
            if (c is Button && read.Read())
            {
                    c.Text = (read["name"].ToString());
            }
    }
     read.Close();
     con.Close();
