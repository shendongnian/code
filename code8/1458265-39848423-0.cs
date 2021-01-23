                DataTable Customers  = new DataTable();//fill this table from db
                DataTable CustomersContacts = new DataTable();//fill this table from db
                List<string> NoContactCus = new List<string>();
                foreach (DataRow Customer in Customers.Rows)
                {
                    DataRow[] contacts = CustomersContacts.Select(string.Format("customerID={0}", Customer["customerID"].ToString()));
                    if (contacts.Count() == 0)
                        NoContactCus.Add(Customer["customerID"].ToString());
                }
