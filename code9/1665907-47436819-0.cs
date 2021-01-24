    private async Task WriteDataToFile(List<ViewModel> data, string path)
    {
        using (var fs = new FileStream(path, FileMode.CreateNew, FileAccess.ReadWrite))
        {
            var sb = new StringBuilder();
            // Loop through the data and build the string.
            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            await fs.WriteAsync(bytes, 0, bytes.Length);
        }
    }
