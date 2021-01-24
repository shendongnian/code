Directory.GetFiles(_Task.[PATH], "[PATTERN]", SearchOption.AllDirectories).ToList<string>();
    private async Task<MyTaskResults> GetFileListsAsync(MyTaskResults _Task)
    {
        if (!string.IsNullOrEmpty(_Task.TextDirPath))
            _Task.TextDirPathResult = await Task.Run(() =>
            {
                return Directory.GetFiles(_Task.TextDirPath, 
                                         "*.txt", 
                                          SearchOption.AllDirectories).ToList<string>();
                //Thread.Sleep(4000);
                //return new List<string> {TextDirPathResult Completed"};
                //return FileList.GetFileList(_Task.TextDirPath);
            });
        if (!string.IsNullOrEmpty(_Task.ImagesDirPath))
            _Task.ImagesDirPathResult = await Task.Run(() =>
            {
                return Directory.GetFiles(_Task.ImagesDirPath, 
                                         "*.jpg", 
                                          SearchOption.AllDirectories).ToList<string>();
                //Thread.Sleep(3000);
                //return new List<string> {"TextDirPathResult Completed"};
                //return FileList.GetFileList(_Task.ImagesDirPath);
            });
        if (!string.IsNullOrEmpty(_Task.NativesDirPath))
            _Task.NativesDirPathResult = await Task.Run(() =>
            {
                return Directory.GetFiles(_Task.NativesDirPath, 
                                         "*.dll", 
                                          SearchOption.AllDirectories).ToList<string>();
                //Thread.Sleep(3000);
                //return new List<string> {"TextDirPathResult Completed"};
                //return FileList.GetFileList(_Task.NativesDirPath);
            });
        return _Task;
    }
