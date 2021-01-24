    private void CheckIfProductExists()
    {
        using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(
            new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
        {
            int productCount = conn.Query<int>(
                "SELECT COUNT(*) from [Product] where [Name] like ?", 
                DescriptionBox.Text);
    
            if (productCount  > 0)
            {
                //Product exist
            }
            else
            {
                //Product doesn't exist.
            }
        }
    }
