    public static void AddItems(StoreItems i) { 
        using(var con = new SqlConnection(DAL.cs) {
            con.Open();
            var sql = "INSERT INTO AlbumsTb ( AlbumName, Artist, Genre, DateReleased, Price, Downloads, Listens, RecordLabel, DateAdded, AlbumArt) VALUES( @AlbumName, @Artist, @Genre, @DateReleased, @Price, @Downloads, @Listens, @RecordLabel, @DateAdded, @AlbumArt)";
            using(var com = new SqlCommand(sql, con) {
                com.Parameters.AddWithValue("@AlbumName", SqlDbType.VarChar).Value = i.AlbumName;
                com.Parameters.AddWithValue("@Artist", SqlDbType.VarChar).Value = i.Artist;
                com.Parameters.AddWithValue("@Genre", SqlDbType.VarChar).Value = i.Genre;
                com.Parameters.AddWithValue("@DateReleased", SqlDbType.Date).Value = i.DateReleased;
                com.Parameters.AddWithValue("@Price",i.Price);
                com.Parameters.AddWithValue("@Downloads", i.Downloads);
                com.Parameters.AddWithValue("@Listens", i.Listens);
                com.Parameters.AddWithValue("@RecordLabel", SqlDbType.VarChar).Value = i.RecordLabel;
                com.Parameters.AddWithValue("@DateAdded", DateTime.Now.ToString());
                com.Parameters.AddWithValue("@AlbumArt", SqlDbType.VarBinary).Value = i.AlbumArt;
                com.ExecuteNonQuery();
            }
        }
    }
    
