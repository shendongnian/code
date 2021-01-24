    while (dr.Read())
    {
	    string cari_code = dr.GetString(dr.GetOrdinal("ITEMNMBR"));
 	    textBox2.Text = cari_code;
	    string intFromSmallInt = 
        Convert.ToString(dr.GetInt16(dr.GetOrdinal("ITEMTYPE")));
	    textBox12.Text = intFromSmallInt;
	    //con.Close();
    }
