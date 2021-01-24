    SqlConnection con2 = new SqlConnection(@"Data Source=GLSPL06-PC\GLSPL06;Initial Catalog=example;User ID=sa;Password=sa@123");
    con2.Open();
    SqlCommand cd = new SqlCommand("insertmaster", con2);
    cd.CommandType = CommandType.StoredProcedure;
    cd.Parameters.AddWithValue("@name", txtname.Text.Trim());
    cd.Parameters.AddWithValue("@age", txtage.Text.Trim());
    cd.Parameters.AddWithValue("@gender", Radiogender.SelectedItem.ToString());
    string id = cd.GetScalar();
    con2.Close();
