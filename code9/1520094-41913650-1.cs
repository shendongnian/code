    public static class DirectoryHelper
    {
        public static IEnumerable<string> EnumerateFiles( 
            string path, 
            SearchOption searchOption, 
            params string[] searchPatterns )
        {
            if ( searchPatterns == null )
                throw new ArgumentNullException( nameof( searchPatterns ) );
            IEnumerable<string> result = new string[] { };
            foreach ( var searchPattern in searchPatterns )
            {
                result = result.Concat( Directory.EnumerateFiles( path, searchPattern, searchOption ) );
            }
            return result;
        }
    }
