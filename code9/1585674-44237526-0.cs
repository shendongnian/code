    String query = "SELECT No_ic as [I/C No.], Name as [Name], Program as [Program], No_Matric as [Matric No.], No_HP as [Handphone No.], Address as [Address], State as [State], Kohort as [Kohort] FROM Student";
    List<String> conditions = new List<String>();
    if (comboBox1.Text.Length > 0)
    {
        conditions.Add("Program LIKE '" + comboBox1.Text + "%' ");
    }
    if (comboBox2.Text.Length > 0)
    {
        conditions.Add("State LIKE '" + comboBox2.Text + "%' ");
    }
    if (comboBox3.Text.Length > 0)
    {
        conditions.Add("Kohort LIKE '" + comboBox3.Text + "%' ");
    }
    
    if (conditions.Count > 0)
    {
        query = query + " WHERE " + String.Join(" AND ", conditions.ToArray())
    }
    SqlDataAdapter sda = new SqlDataAdapter(query, con);
    sda.Fill(ds);
