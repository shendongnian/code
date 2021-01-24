    public class FileSytemInfoErrorArgs
    {
        public FileSytemInfoErrorArgs( FileSystemInfo fileSystemInfo, Exception error )
        {
            FileSystemInfo = fileSystemInfo;
            Error = error;
        }
        public FileSystemInfo FileSystemInfo { get; }
        public Exception Error { get; }
        public bool Handled { get; set; }
    }
    public static class DirectoryInfoExtensions
    {
        public static long GetTotalSize( this DirectoryInfo di, Action<FileSytemInfoErrorArgs> errorAction = null )
        {
            long size = 0;
            foreach ( var item in di.EnumerateFileSystemInfos() )
            {
                try
                {
                    size += ( item as FileInfo )?.Length
                        ?? ( item as DirectoryInfo )?.GetTotalSize( errorAction )
                        ?? throw new InvalidOperationException();
                }
                catch ( Exception ex )
                {
                    var arg = new FileSytemInfoErrorArgs( item, ex );
                    errorAction?.Invoke( arg );
                    if ( !arg.Handled )
                    {
                        throw;
                    }
                }
            }
            return size;
        }
    }
