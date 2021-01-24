    private void listBoxobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        int SelectedContactID = 0;
        if (listBoxobj.SelectedIndex != -1)
        {
            Data listitem = listBoxobj.SelectedItem as Data;//Get slected listbox item 
            DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
            Db_Helper.DeleteContact(listitem.Id);//Delete selected DB contact Id.
            //remove item from collection
            DB_ContactList.Remove(listitem); 
            //update listbox
            //...
        }
    }
