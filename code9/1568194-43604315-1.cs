            foreach (var customer in listCustomerDetails)
            {
                ListItem ls = new ListItem();
                ls.Text = customer.Value;
                ls.Value = customer.Key;
                listItem.Add(ls);
            }
