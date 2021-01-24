    string LookupByPhone(string name)
    {
        string id = "0";
        var uri = ContactsContract.Contacts.ContentUri;
        var cursor = this.ContentResolver.Query(
                     uri,
                     new String[] { ContactsContract.Contacts.InterfaceConsts.Id },
                     ContactsContract.Contacts.InterfaceConsts.DisplayName +
                     "='" + name + "'", null, null);
        if (cursor.MoveToNext())
        {
            id = cursor.GetString(cursor.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.Id));
        }
        cursor.Close();
        return id;
     }
