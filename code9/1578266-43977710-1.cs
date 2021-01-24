      using (var db = new SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
            {
                var cc = db.Query<Table>("SELECT * from Events");
                lstPersons.DataContext = cc.ToList();
            }
