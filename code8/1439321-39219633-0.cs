    public static List<Customer> GetCustomer(int customerID)
    {
        Customer customer = new Customer();
        List<Customer> list = new List<Customer>();
        string query = "SELECT * FROM [Customers] WHERE [CustomerID] = @CustomerID";
        SqlCommand cmd = new SqlCommand(query);
        cmd.Parameters.AddWithValue("@CustomerID", SqlDbType.Text).Value = customerID;
        DataTable dt = DbUtility.GetRecordsInDataTable(cmd);
        if (dt.Rows.Count > 0)
        {
            customer.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"]);
            customer.LoginID = dt.Rows[0]["LoginID"].ToString();
            customer.Password = dt.Rows[0]["Password"].ToString();
            customer.CustomerName = dt.Rows[0]["CustomerName"].ToString();
            customer.ShopName = dt.Rows[0]["ShopName"].ToString();
            customer.Address = dt.Rows[0]["Address"].ToString();
            customer.Mobile1 = dt.Rows[0]["Mobile1"].ToString();
            customer.Mobile2 = dt.Rows[0]["Mobile2"].ToString();
            customer.ReferenceNumber = dt.Rows[0]["ReferenceNumber"].ToString();
            customer.SignUpDate = Convert.ToDateTime(dt.Rows[0]["SignUpDate"]);
            customer.Enabled = Convert.ToBoolean(dt.Rows[0]["Enabled"]);
            list.Add(customer);            
            return list;
        }
        else
        {
            return null;
        }
    }
