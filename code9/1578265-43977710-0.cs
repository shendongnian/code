     using (var db = new SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
            {
                listPerson = db.Table<Persons>().Where(x => x.Property == "P" && x.Status == 0).ToList();
            } 
    lstPersons.DataContext = listPerson;
