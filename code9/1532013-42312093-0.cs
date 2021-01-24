    public async Task GetFile()
    {
        Windows.Storage.Pickers.FileOpenPicker picker = new Windows.Storage.Pickers.FileOpenPicker();
        picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
        picker.FileTypeFilter.Add(".txt");
        //Prompt the user to open the log file:
        Windows.Storage.StorageFile logFile = await picker.PickSingleFileAsync();
        try
        {
            using (var stream = await logFile.OpenStreamForReadAsync())
            using (var reader = new StreamReader(stream))
            {
                var line = await reader.ReadLineAsync();
                Debug.WriteLine($"The first line: {line} - waiting");
                await Task.Delay(10000);
                line = await reader.ReadLineAsync();
                Debug.WriteLine($"The next line: {line} - waiting");
            }
        }
        catch (Exception exc)
        {
            Debug.WriteLine($"Exception {exc.Message}");
        }
    }
