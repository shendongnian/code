    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].Connect    ionString);
    // Convert the textbox text to a DateTime variable
    DateTime myDate = DateTime.ParseExact(datebox.Text, "dd-MM-yy", System.Globalization.CultureInfo.InvariantCulture);
    SqlCommand com = new SqlCommand(query, con);
    string query= "insert into record (dob) values(@db)";
    com.Parameters.AddWithValue("@db", myDate);
    com.ExecuteNonQuery();
