    [WebMethod]
    public static string contacters()
    {
        SqlConnection con = new SqlConnection(ConnectionString);
        List<object> obj = new List<object>();
        SqlCommand cmd = new SqlCommand("select * from authors", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        for(int i=0; i<ds.Tables[0].Rows.Count; i++)
        {
            obj.Add(ds.Tables[0].Rows[i][0]);
            obj.Add(ds.Tables[0].Rows[i][1]);
            obj.Add(ds.Tables[0].Rows[i][2]);
        }enter code here
        JavaScriptSerializer ser = new JavaScriptSerializer();
        var json = ser.Serialize(obj);
        return json;
    }
