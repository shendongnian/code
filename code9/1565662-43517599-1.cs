    var path = Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData );
    var dir = new DirectoryInfo( path );
    var totalSize = dir.GetTotalSize(
        errorAction: e =>
        {
            // Console.WriteLine( "{0}: {1}", e.FileSystemInfo.FullName, e.Error.Message );
            e.Handled = true;
        } );
