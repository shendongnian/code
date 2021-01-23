                List<CustomerGroup> groups = new List<CustomerGroup>();
                List<Contact_List> contact_list = new List<Contact_List>();
                List<Contacts> contacts = (from g in groups
                                           join c in contact_list on g.Customer_Code equals c.Customer_Code
                                           select new { groupName = g.Customer_Group_Name, c })
                                           .Select(x => new Contacts() {
                                               FirstName = x.c.First_Name,
                                               LastName = x.c.Last_Name,
                                               ContactNo = x.c.Contact_No,
                                               GroupName = x.groupName
                                           }).ToList();
