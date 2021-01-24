    private async Task<MyTaskResults> GetFileLists(MyTaskResults _Task)
    {
        if (!string.IsNullOrEmpty(_Task.TextDirPath))
            _Task.TextDirPathResult = await Task.Run(() =>
            {
                Thread.Sleep(4000);
                return "TextDirPathResult Completed";
                //return FileList.GetFileList(_Task.TextDirPath);
            });
        if (!string.IsNullOrEmpty(_Task.ImagesDirPath))
            _Task.ImagesDirPathResult = await Task.Run(() =>
            {
                Thread.Sleep(3000);
                return "TextDirPathResult Completed";
                //return FileList.GetFileList(_Task.ImagesDirPath);
            });
        if (!string.IsNullOrEmpty(_Task.NativesDirPath))
            _Task.NativesDirPathResult = await Task.Run(() =>
            {
                Thread.Sleep(3000);
                return "TextDirPathResult Completed";
                //return FileList.GetFileList(_Task.NativesDirPath);
            });
        return _Task;
    }
