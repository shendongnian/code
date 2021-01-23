    public string login(string unamePI, string passPI)
    {
        DataTable mytable = new DataTable();
        string result = "";
        mytable = GetTableWithQueryParams("select * from UYE where USERNAME ={0} and PASSWORD={1}", unamePI, passPI);
    
        if (mytable.Rows.Count > 0)
        {
            result = string.Format("Welcome {0}", mytable.Rows[0]["sicilKod"].ToString());
        }
        
        return result;
       
    }
