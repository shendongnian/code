    DataTable table = new DataTable();
    string sessionVar = "";
    
    MySqlCommand select = new MySqlCommand("SELECT personID, address_addressID from person WHERE email='" + emailAddress + "' and password = '" + passwordR + "'", connect); //brings back the person ID if user details are correct            
    using (MySqlDataAdapter adapter = new MySqlDataAdapter(select))
        {
            adapter.Fill(table);
    
            sessionVar = table.Rows[0]["personID"].ToString();
            Session["personID"] = sessionVar;
    
            int sessionVarAddress = Int32.Parse(table.Rows[0]["address_addressID"].ToString());
            Session["address_addressId"] = sessionVarAddress;
    }
