    public List<CustomerAccountManager> LoadAllCustomers() {
        string sql;
        SqlCommand cmd;
        SqlDataAdapter sqlda;
        DataSet sqlds = new DataSet();
        decimal? Chequing = null;
        decimal? Saving = null;
        int CustomerNumber = 0;
        string FirstName = string.Empty;
        string LastName = string.Empty;
        List<CustomerAccountManager> AllCustomers = new List<CustomerAccountManager>();
        sql = @"SELECT c.CustomerNumber, c.FirstName, c.LastName,
                       ac.Balance AS Chequing, as.Balance AS Saving
                FROM Customer c
                LEFT JOIN Account ac ON ac.CustomerNumber = c.CustomerNumber
                                     AND ac.AccountType = 'C'
                LEFT JOIN Account as ON as.CustomerNumber = c.CustomerNumber
                                     AND as.AccountType = 'S'";
        cmd = new SqlCommand(sql, Connection);
        sqlda = new SqlDataAdapter(cmd);
        sqlda.Fill(sqlds);
        foreach (DataRow cust in sqlds.Tables[0].Rows) {
           CustomerNumber = Convert.ToInt32(cust["CustomerNumber"]);
           FirstName = Convert.ToString(cust["FirstName"]);
           LastName = Convert.ToString(cust["LastName"]);
           Chequing = Convert.ToDecimal(cust["Chequing"]);
           Saving = Convert.ToDecimal(cust["Saving"]);
           AllCustomers.Add(new CustomerAccountManager
                                (CustomerNumber, FirstName, LastName, Chequing, Saving));
         }
        return (AllCustomers);
    }
