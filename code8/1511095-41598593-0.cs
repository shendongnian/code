    public static class SomeLookups
    {
        private static object _lock = new object( );
        private static Task<IList<string>> _foosAsync;
        public static Task<IList<string>> GetFoosAsync()
        {
            lock ( _lock )
            {
                return _foosAsync = _foosAsync ?? PrivateGetFoosAsync( );
            }
        }
        private static async Task<IList<string>> PrivateGetFoosAsync()
        {
            var list = new List<string>( );
            for ( int i = 0; i < 20; i++ )
            {
                await Task.Delay( 200 ).ConfigureAwait( false );
                list.Add( "item " + i );
            }
            return list.AsReadOnly( );
        }
    }
