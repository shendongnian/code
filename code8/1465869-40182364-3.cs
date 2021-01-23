    public List<CustomerListItem> GetCustomerListItem()
    {
        List<CustomerListItem> customerlist = null;
        CustomerListItem item = null;
        using (CustomerTableAdapter adp = new CustomerTableAdapter())
        {
            using (DAL.dstCustomer.CustomerDataTable tbl = adp.GetCustomerDataList())
            {
                customerlist = new List<CustomerListItem>();
                foreach (var row in tbl)
                {
                    item = new CustomerListItem();
                    item.FirstName = row.FirstName;
                    item.LastName = row.LastName;
                    item.Phone1 = row.Phone1;
                    string mystring = row.CountryId.ToString(); //i tried to convert it to string but it still gives me the error that 'The value for column 'CountryId' in table 'Customer' is DBNull.'
                    item.CountryId = mystring;
                    //item.NationalityId = row.NationalityId;
                    //Here's the new line, where we actually populate our new model property
                    item.CountryName  = row.CountryName;
                    customerlist.Add(item);
                }
            }
        }
        return customerlist;
    }
