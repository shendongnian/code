        public static void ZipDirectory(string input, string output, CompressionLevel level)
        {
            input = Path.GetFullPath(input);
            using (var fs = File.OpenWrite(output))
            using (var za = new ZipArchive(fs, ZipArchiveMode.Create))
            {
                foreach (var filePath in Directory.GetFiles(input, "*", SearchOption.AllDirectories).OrderBy(x => x))
                {
                    var name = filePath.Replace(input, "").TrimStart('\\', '/');
                    var e = za.CreateEntry(name, level);
                    using (var zes = e.Open())
                    {
                        using (var fes = File.OpenRead(filePath))
                        {
                            fes.CopyTo(zes);
                        }
                    }
                }
            }
            using (var za = ZipFile.Open(output, ZipArchiveMode.Update))
            {
                foreach (var e in za.Entries)
                {
                    e.LastWriteTime = new DateTimeOffset(1980, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
                }
            }
        }
