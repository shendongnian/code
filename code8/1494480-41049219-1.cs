    List<Customer> customers = new List<Customer>();
                
                if (rdr.HasRows)
                {
                    Customer CurrentCustomer = new Customer();
                    while (rdr.Read())
                    {
                        /*
                       Since the data is sorted by CustID, 
                       I only add the parent class when it changes.
                       */
                        if (CurrentCustomer.CustomerID != rdr["CustID"].ToString())
                        {
                            CurrentCustomer = new Customer()
                            {
                                CustomerID = rdr["CustID"].ToString(),
                                CustomerName = rdr["CustomerName"].ToString()
                            };
                            customers.Add(CurrentCustomer);
                        }
                        CurrentCustomer.Preferences.Add(rdr["PreferanceName"].ToString(),
                             rdr["PreferenceValue"].ToString());
                    }
                }
