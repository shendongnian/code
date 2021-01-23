    using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null)) {
        if (isoStore.FileExists("contacts.dat")) {
            IsolatedStorageFileStream fs = isoStore.OpenFile("contacts.dat", System.IO.FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            contacts = (List<Contact>) bf.Deserialize(fs);
        }else {
            // We don't have a backup file, create some dummy entries
            contacts = new List<Contact>();
            contacts.Add(new Contact("John Smith", "1234567"));
            contacts.Add(new Contact("Emma Brown", "7654321"));
        }
    }
    MyDataGrid.ItemsSource = contacts;
