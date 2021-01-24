                StorageFolder sharedFonts = Windows.Storage.ApplicationData.Current.GetPublisherCacheFolder("test");
                var sqlpath = System.IO.Path.Combine(sharedFonts.Path, "MyDb.db");
                using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
                {
                    conn.CreateTable<Contact>();
                    for (var i = 0; i < 100; i++)
                    {
                        Contact contact = new Contact()
                        {
                            Id = i,
                            Name = "A"
                        };
                        conn.Insert(contact);
                    }
                }
