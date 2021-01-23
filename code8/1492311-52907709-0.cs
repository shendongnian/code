    private async Task Upload(DropboxClient dbx, string folder, string file, string fileToUpload)
        {
            using (var mem = new MemoryStream(File.ReadAllBytes(fileToUpload)))
            {
                var updated = await dbx.Files.UploadAsync(
                    folder + "/" + file,
                    WriteMode.Overwrite.Instance,
                    body: mem);
                Console.WriteLine("Saved {0}/{1} rev {2}", folder, file, updated.Rev);
            }
        }
