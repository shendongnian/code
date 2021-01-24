    private static async Task Download(DropboxClient dbx, string folder, string file)
    {
        string path = Path.Combine(folder, file);
        var args = new Dropbox.Api.Files.DownloadArg(path);
        using (var response = await dbx.Files.DownloadAsync(args))
        {
            using (var sw = new StreamWriter(@"c:\prueba\localfile.pdf"))
            {
                Console.WriteLine(await response.GetContentAsStringAsync());
                var bytes = await response.GetContentAsByteArrayAsync();
                await sw.BaseStream.WriteAsync(bytes, 0, bytes.Length);
                Console.ReadKey();
            }
        }
    }
