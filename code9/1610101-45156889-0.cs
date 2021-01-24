     SqlConnection con = new SqlConnection(@"my connection string");
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("Select [Person_FirstName]     from person where Person_LastName='" + comboBox1.ValueMember + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        DataRow dr=dt.Rows[0];    
        TextBox.Text=dr[0].ToString();
