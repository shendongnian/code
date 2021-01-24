    SqlHelper sho = new SqlHelper();
    public bool alreadyexist()
            {
    string[] str = { "@catname", "@proname" };       
    string[] obj = { comboproductname.Text, comboitemname.Text };
    SqlDataReader sdrr = sho.GetReaderByCmd("sp_item_alreadyex", str, obj);
    if (sdrr.Read())
    {
        sdrr.Close();
        sho.CloseConnection();
        return true;
    }
    else
    {
        sdrr.Close();
        sho.CloseConnection();
        return false;
    }
	
