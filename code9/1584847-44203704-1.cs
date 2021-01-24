    class Program
    {
        static void Main( string[] args )
        {
            DirectoryRenamer.RenameDirectoryTree( 
                @"C:\Test\FolderMatchALevel", 
                name => name.Replace( "MatchA", "AMatch" ) );
        }
    }
