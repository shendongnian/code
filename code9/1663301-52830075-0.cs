    public async Task<byte[]> ReadFileAsync(string path)
    {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read,FileShare.Read))
            {
                var result = new byte[fileStream.Length];
                await fileStream.ReadAsync(result, 0, (int)fileStream.Length);
                return result;
            }
    }
