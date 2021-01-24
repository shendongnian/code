    public static class ZipArchiveExtensions {    
        public static Stream Compress(this IEnumerable<FileModel> files) {
            if (files.Any()) {
                var ms = new MemoryStream();
                using(var archive = new ZipArchive(ms, ZipArchiveMode.Create, leaveOpen: true)) {
                    foreach (var file in files) {
                        var entry = archive.add(file);
                    }
                }
                ms.Position = 0;
                return ms;
            }
            return null;
        }
    
        private static ZipArchiveEntry add(this ZipArchive archive, FileModel file) {
            var entry = archive.CreateEntry(file.FileName, CompressionLevel.Fastest);
            using (var stream = entry.Open()) {
                file.FileStream.CopyTo(stream);
            }
            return entry;
        }
    }
