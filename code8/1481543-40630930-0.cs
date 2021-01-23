    con.Open();
    SqlCommand cmd = con.CreateCommand();
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = "select prumos from dbo.modelos";
    SqlDataReader dr = cmd.ExecuteReader();
    if(dr.Read())
    { 
        // if dr.Read() returns true we already know that dr.HasRows was also true
        object value;
        try
        {
            value = dr["prumos"];
        }
        catch(IndexOutOfRangeException) // thrown if there is no such column
        {
            value = null;
        }
        string check = value != null : value.ToString() : null;
        textBox13.Visible = (check == "2" || check == "3");
        textBox18.Visible = (check == "2" || check == "3");
        textBox17.Visible = (check == "2" || check == "3");
        textBox14.Visible = check == "3";
        textBox16.Visible = check == "3";
        textBox15.Visible = check == "3";
        label16.Visible = (check == "2" || check == "3");
        label20.Visible = check == "3";
    }
    else 
    {
       // what to do if there is no row?
    }
    dr.Close();
    con.Close();
