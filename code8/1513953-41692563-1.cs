    public void Init()
    {
        _loadCustomers = new SqlCommand(...);
        _loadCustomers.Parameters.Add("@name",SqlDbType.NVarChar,20);
        ....
        _myGridAdapter = new SqlDataAdapter(_loadCustomers);
        ...
    }
