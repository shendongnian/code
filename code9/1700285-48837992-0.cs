    public interface IMainViewCallbacks
    {
            bool GetPathViaOpenDialog(out string filePath, string szFilter, 
                     string szDefaultExt, string szInitialDir);
            bool GetPathViaSaveDialog(out string filePath, string szFilter, 
                     string szDefaultExt, string szInitialDir);
            bool GetFolderPath(out string folderPath);
            MessageBoxResult MessageBox(string messageBoxText, string caption, 
                      MessageBoxButton button, MessageBoxImage icon);
    }
