    public static class DirectoryRenamer
    {
        public static void RenameDirectoryTree( string path, Func<string, string> renamingRule )
        {
            var di = new DirectoryInfo( path );
            RenameDirectoryTree( di, renamingRule );
        }
        public static void RenameDirectoryTree( DirectoryInfo directory, Func<string, string> renamingRule )
        {
            InternalRenameDirectoryTree( directory, renamingRule );
            var currentName = directory.Name;
            var newName = renamingRule( currentName );
            if ( currentName != newName )
            {
                var newDirname = Path.Combine( directory.Parent.FullName, newName );
                directory.MoveTo( newDirname );
            }
        }
        static void InternalRenameDirectoryTree( DirectoryInfo di, Func<string, string> renamingRule )
        {
            foreach ( var item in di.GetFileSystemInfos() )
            {
                var subdir = item as DirectoryInfo;
                if ( subdir != null )
                {
                    InternalRenameDirectoryTree( subdir, renamingRule );
                    var currentName = subdir.Name;
                    var newName = renamingRule( currentName );
                    if ( currentName != newName )
                    {
                        var newDirname = Path.Combine( subdir.Parent.FullName, newName );
                        subdir.MoveTo( newDirname );
                    }
                }
                var file = item as FileInfo;
                if ( file != null )
                {
                    var currentName = Path.GetFileNameWithoutExtension( file.Name );
                    var newName = renamingRule( currentName );
                    if ( currentName != newName )
                    {
                        var newFilename = Path.Combine( file.DirectoryName, newName + file.Extension );
                        file.MoveTo( newFilename );
                    }
                }
            }
        }
    }
