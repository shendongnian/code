        public async Task<byte[]> ZipAsync(IEnumerable<KeyValuePair<string, Stream>> files, string mime, string password)
        {
            ExceptionHelper.ThrowIfNull(nameof(files), files);
            ExceptionHelper.ThrowIfNull(nameof(mime), mime);
            using (var output = new MemoryStream())
            {
                using (var zipStream = new ZipOutputStream(output))
                {
                    zipStream.SetLevel(9);
                    if (!string.IsNullOrEmpty(password))
                    {
                        zipStream.Password = password;
                    }
                    foreach (var file in files)
                    {
                        var newEntry = new ZipEntry($"{file.Key}.{mime}") { DateTime = DateTime.Now };
                        zipStream.PutNextEntry(newEntry);
                        await file.Value.CopyToAsync(zipStream);
                        zipStream.CloseEntry();
                    }
                }
                return output.ToArray();
            }
        }
