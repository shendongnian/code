    static class ZipFileWithProgress
    {
        public static void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, IProgress<double> progress)
        {
            sourceDirectoryName = Path.GetFullPath(sourceDirectoryName);
            FileInfo[] sourceFiles =
                new DirectoryInfo(sourceDirectoryName).GetFiles("*", SearchOption.AllDirectories);
            long totalBytes = sourceFiles.Sum(f => f.Length), currentBytes = 0;
            using (ZipArchive archive = ZipFile.Open(destinationArchiveFileName, ZipArchiveMode.Create))
            {
                foreach (FileInfo file in sourceFiles)
                {
                    // NOTE: naive method to get sub-path from file name, relative to
                    // input directory. Production code should be more robust than this.
                    // Either use Path class or similar to parse directory separators and
                    // reconstruct output file name, or change this entire method to be
                    // recursive so that it can follow the sub-directories and include them
                    // in the entry name as they are processed.
                    string entryName = file.FullName.Substring(sourceDirectoryName.Length + 1);
                    ZipArchiveEntry entry = archive.CreateEntry(entryName);
                    using (Stream inputStream = File.OpenRead(file.FullName))
                    using (Stream outputStream = entry.Open())
                    {
                        Stream progressStream = new StreamWithProgress(inputStream,
                            new BasicProgress<int>(i =>
                            {
                                currentBytes += i;
                                progress.Report((double)currentBytes / totalBytes);
                            }), null);
                        progressStream.CopyTo(outputStream);
                    }
                }
            }
        }
    }
