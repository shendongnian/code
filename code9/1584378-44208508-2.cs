    if (File.Exists(_path))
    {
        using (FileStream file = System.IO.File.OpenRead(_path))
        {
            var data = File.ReadAllBytes(_path);
            int length = data.Length;
            MemoryStream ms = new MemoryStream(data, 0, length, true, true);
            result.Content = new ByteArrayContent(ms.GetBuffer());
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = id + ".pdf"
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            file.Dispose();
        }
        File.Delete(_path);
    }
