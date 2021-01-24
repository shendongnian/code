    class ContactListViewModel 
    {
         .....
         private ObservableCollection<Contacts> _contactsCollection;
         private void OpenAddWindow()
         {
             AddContact contact = new AddContact();
             contact.DataContext = this;
             if(contact.ShowDialog() == true)
             {
                  _contactsCollection.Add(contact.newContact);
             }
         } 
    }
