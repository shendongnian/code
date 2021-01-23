    using(OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\db\\it.accdb"))
    {
        con.Open();
    
        //... stuff
    
        DataTable dt;
        using(OleDbDataAdapter da = new OleDbDataAdapter(cmd))
        {
             //stuff relate to db adapter
        }
        
    }
