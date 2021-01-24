    public static class AsyncFile
    {
        // Tweak as you see fit.
        private const int MaxLinesPerBatch = 1000;
        private const FileMode ReadMode = FileMode.Open;
        private const FileAccess ReadAccess = FileAccess.Read;
        private const FileShare ReadShare = FileShare.Read;
        public static async Task ReadAllLinesAsync(
            string path,
            Action<string> lineCallback,
            Action<double?> progress = null,
            Encoding encoding = null)
        {
            using (var stream = new FileStream(path, ReadMode, ReadAccess, ReadShare))
            using (var reader = new StreamReader(stream, encoding ?? Encoding.UTF8))
            {
                var fileSize = stream.CanSeek ? stream.Length : default(long?);
                var currentProgress = fileSize < 1L ? 0d : 0d / fileSize;
                progress?.Invoke(currentProgress);
                var lines = new string[MaxLinesPerBatch];
                int linesRead;
                var batchFunction = CreateBatchReadFunction(reader, lines);
                while ((linesRead = await Task.Run(batchFunction)) > 0)
                {
                    for (var i = 0; i < linesRead; i++)
                        lineCallback(lines[i]);
                    if (currentProgress == null)
                        continue;
                    var newProgress = ((100L * stream.Position) / fileSize) / 100d;
                    if (newProgress > currentProgress)
                        progress?.Invoke(currentProgress = newProgress);
                }
                if (currentProgress < 1d)
                    progress?.Invoke(1d);
            }
        }
        private static Func<int> CreateBatchReadFunction(
            StreamReader reader,
            string[] lines)
        {
            return () =>
                   {
                       string line;
                       var count = 0;
                       while (count < lines.Length && (line = reader.ReadLine()) != null)
                           lines[count++] = line;
                       return count;
                   };
        }
    }
