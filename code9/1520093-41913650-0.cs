    IEnumerable<string> myFilesQuery = new string[] { };
    myFilesQuery = myFilesQuery.Concat( Directory.EnumerateFiles( dir, "*.avi", SearchOption.AllDirectories ) );
    myFilesQuery = myFilesQuery.Concat( Directory.EnumerateFiles( dir, "*.mp4", SearchOption.AllDirectories ) );
    myFilesQuery = myFilesQuery.Concat( Directory.EnumerateFiles( dir, "*.jpg", SearchOption.AllDirectories ) );
    // nothing will happen until we call
    IList<string> myFiles = myFilesQuery.ToList( );
