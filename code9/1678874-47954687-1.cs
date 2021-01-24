    public List<CustomerAccountManager> LoadAllCustomers() {
        SqlCommand cmd1, cmd2;
        SqlDataAdapter sqlda;
        DataSet sqlds = new DataSet();
        decimal? Chequing = null;
        decimal? Saving = null;
        int CustomerNumber = 0;
        string FirstName = string.Empty;
        string LastName = string.Empty;
        List<CustomerAccountManager> AllCustomers = new List<CustomerAccountManager>();
        cmd1 = new SqlCommand("SELECT Customer.CustomerNumber, FirstName, LastName FROM Customer", Connection);
        cmd2 = new SqlCommand("SELECT Account.CustomerNumber, AccountType, Balance FROM Account WHERE AccountType = 'C' OR AccountType = 'S' ", Connection);
        //sqlds.Tables.Add("Customers");
        //sqlds.Tables.Add("Acct");
        sqlda = new SqlDataAdapter(cmd1);
        sqlda.Fill(sqlds.Tables["Customers"]);
        sqlda = new SqlDataAdapter(cmd2);
        sqlda.Fill(sqlds.Tables["Acct"]);
        foreach (DataRow cust in sqlds.Tables[0].Rows) {
            foreach (DataRow acct in sqlds.Tables[1].Rows) {
                CustomerNumber = Convert.ToInt32(cust["CustomerNumber"]);
                int CustomerNumberAcct = Convert.ToInt32(acct["CustomerNumber"]);
                if (CustomerNumber == CustomerNumberAcct) {
                    CustomerNumber = Convert.ToInt32(cust["CustomerNumber"]);
                    FirstName = Convert.ToString(cust["FirstName"]);
                    LastName = Convert.ToString(cust["LastName"]);
                    string AcctType = Convert.ToString(acct["AccountType"]);
                    if (AcctType == "C")
                        Chequing = Convert.ToDecimal(acct["Balance"]);
                    if (AcctType == "S")
                        Saving = Convert.ToDecimal(acct["Balance"]);
                }
            }
            AllCustomers.Add(new CustomerAccountManager(CustomerNumber, FirstName, LastName, Chequing, Saving));
         }
        return (AllCustomers);
    }
