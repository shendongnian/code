                StorageFolder sharedFonts = Windows.Storage.ApplicationData.Current.GetPublisherCacheFolder("test");
                var sqlpath = System.IO.Path.Combine(sharedFonts.Path, "MyDb.db");
                using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
                {
                    var query = conn.Table<Contact>().Where(v => v.Name.Equals("A"));
                    foreach (var stock in query)
                        Debug.WriteLine("contact: " + stock.Id);
                }
