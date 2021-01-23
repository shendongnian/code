    protected override void OnClosing(CancelEventArgs e) {
        base.OnClosing(e);
        using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null)) {
            if (isoStore.FileExists("contacts.dat")) {
                // We already have an old one, delete it
                isoStore.DeleteFile("contacts.dat");
            }
            using (IsolatedStorageFileStream fs = isoStore.CreateFile("contacts.dat")) {
               BinaryFormatter bf = new BinaryFormatter();
               bf.Serialize(fs, contacts);
            }
        }
    }
