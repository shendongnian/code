    private IEnumerable<Contacts> JoinTables(IEnumerable<Contact_List> contactLists, IEnumerable<CustomerGroup> customerGroups)
    {    
        return contactLists.Join(customerGroups, 
                                 x => x.Customer_Code, 
                                 y => y.Customer_Code, 
                                 (x, y) => new Contacts()
                                 {
                                    ContactNo = x.Contact_No,
                                    FirstName = x.First_Name,
                                    LastName = x.Last_Name,
                                    GroupName = y.Customer_Group_Name
                                 });
    }
