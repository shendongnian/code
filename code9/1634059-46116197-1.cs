    try
    {
        using (var connection = new 
       SQLiteConnection(Path.Combine(dir.AbsolutePath, "album.db")))
        {
            return connection.Table<AlbumTable>().FirstOrDefault(x => x.OrderId 
            == orderId);
        }
    }
    catch (SQLiteException ex)
    {
        return null;
    }
