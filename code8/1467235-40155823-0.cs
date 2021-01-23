    bool valid = true;
    if (string.IsNullOrWhiteSpace(textBoxCity.Text))
    {
         valid = false;
         MessageBox.Show("This cannot be empty");
    }
    if(valid)
    {
        cmd.Parameters.Add("@city", SqlDbType.Int).Value = textBoxCity.Text;
        //execute sql query here
    }
