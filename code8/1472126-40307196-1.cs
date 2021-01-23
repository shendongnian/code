    public static class FavoritesManager
    {
        List<string> _favorites = null;
        public static async Task LoadFromStorageAsync()
        {
            _favorites = 
                JsonConvert.DeserializeObject<List<string>>( 
                    await FileIO.ReadAllTextAsync( "somefile.txt" ) );
        }
        public static async Task AddAsync( string text )
        {
            _favorites.Add( text );
            await FileIO.WriteAllTextAsync( "somefile.txt",
               JsonConvert.SerializeObject( _favorites ) );                    
        }
        public static IEnumerable<string> GetFavorites()
        {
           return _favorites;
        }
    }
