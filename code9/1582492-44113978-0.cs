    private static async void OnChanged(object source, FileSystemEventArgs e)
    {
        await Task.Delay(TimeSpan.FromSeconds(2)).ConfigureAwait(false);
        File.Move(e.FullPath, Path.Combine(targetFolder, e.Name));
    }
