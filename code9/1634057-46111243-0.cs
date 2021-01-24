    public AlbumTable getRow(string orderId)
    {
        try
        {
            using (var connection = new SQLiteConnection(Path.Combine(dir.AbsolutePath, "album.db")))
            {
                return connection.Table<AlbumTable>().Where(x => x.OrderId == orderId).SingleOrDefault();
            }
        }
        catch (SQLiteException ex)
        {
            return null;
        }
    }
