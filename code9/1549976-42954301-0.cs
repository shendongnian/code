    public static class FileExtensions
    {
        public static Task<int> DeleteAsync(this IEnumerable<FileInfo> files)
        {
            var count = files.Count();
            Parallel.ForEach(files, (f) =>
            {
                f.Delete();
            });
            return Task.FromResult(count);
        }
        public static async Task<int> DeleteAsync(this DirectoryInfo directory, Func<FileInfo, bool> predicate)
        {
            return await directory.EnumerateFiles().Where(predicate).DeleteAsync();
        }
        public static async Task<int> DeleteAsync(this IEnumerable<FileInfo> files, Func<FileInfo, bool> predicate)
        {
            return await files.Where(predicate).DeleteAsync();
        }
    }
