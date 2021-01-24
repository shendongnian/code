        private void OpenAddWindow()
        {
            AddContact contact = new AddContact();
            contact.DataContext = this;
            if(contact.ShowDialog() == true)
            {
                 //here i have just given messagebox here you can fetch the data membersof AddContact window
                 MessageBox.Show(contact.VariableAssumed);
                 //On add button click in childwindow You can save your new contact in Contacts object(newContact) 
                 //and you can retrieve the newContact here and add it to your Contact list present in parentwindow as below
                 contactList.Add(contact.newContact);
            }
        }
