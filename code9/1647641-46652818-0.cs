     while (dr.Read())
     {
     string cari_code = dr.GetString(dr.GetOrdinal("ITEMNMBR"));
     string intFromSmallInt = Convert.ToString(dr.GetInt16(dr.GetOrdinal("ITEMTYPE")));
     var desc = Convert.ToString(dr.GetOrdinal("itemdesc"));
     if(suggestComboBox2.Text.Equals(desc)){
     textBox12.Text = intFromSmallInt;
       textBox2.Text = cari_code;
     }
     //con.Close();
    }
