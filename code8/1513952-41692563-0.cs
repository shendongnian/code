    public void Init()
    {
        _loadCustomers = new SqlCommand(...);
        _loadCustomers.Parameters.Add("@name",SqlDbType.NVarChar,20);
        ...
    }
    //In another method :
    using(var con=new SqlConnection(myConnectionString)
    {       
        _loadCustomers.Connection=con;
        _loadCustomers.Parameters["@name"].Value = myNameParam;
        con.Open();
        using(var reader=_load.ExecuteReader())
        {
        //...
        }
    }
