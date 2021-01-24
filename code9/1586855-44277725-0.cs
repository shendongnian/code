    string qr1 = "select * from materia ";
    SqlCommand cmd1 = new SqlCommand(qr1, con);
    con.Open();
    SqlDataReader dr1 = cmd1.ExecuteReader(); 
    cmbcat.Items.Clear(); 
    while (dr1.Read()) 
    {
     cmbcat.Items.Add(new Item(dr1["clavemateria"].ToString(), dr1["clavemateria"].ToString())); 
    }
     con.Close();
