    if (textBoxCode.Text != String.Empty && textBoxLastName.Text != String.Empty && textBoxFirstName.Text != String.Empty)
    {
    
        con.Open();
    
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from Student where Code=@Code and Last_Name=@Last_Name and First_Name=@First_Name";
        cmd.Parameters.AddWithValue("@Code", textBoxCode.Text);
        cmd.Parameters.AddWithValue("@Last_Name", textBoxLastName.Text);
        cmd.Parameters.AddWithValue("@First_Name", textBoxFirstName.Text);
    
        int rc = cmd.ExecuteNonQuery();
    
        if (rc > 0)
        {
            MessageBox.Show("Student deleted successfully", "Delete Done", MessageBoxButtons.OK);
        }
        else
        {
            MessageBox.Show("There is no record found for delete!", "Delete Done", MessageBoxButtons.OK);
        }
        con.Close();
        DisplayData();
    
        textBoxCode.Text = String.Empty;
        textBoxFirstName.Text = String.Empty;
        textBoxLastName.Text = String.Empty;
    
    }
