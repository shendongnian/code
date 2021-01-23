    protected string getWhereQuery()
    {
        string query = txtQuery.Text;
        if(string.IsNullOrEmpty(query))
         query=" 1=1";
        return query;
    }
