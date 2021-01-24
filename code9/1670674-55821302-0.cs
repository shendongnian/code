        string filename = string.Format("{0}/{1}_{2}.json", blobname,                         DateTime.UtcNow.ToString("ddMMyyyy_hh.mm.ss.fff"), Guid.NewGuid().ToString("n"));
        using (var writer = await binder.BindAsync<TextWriter>(
                new BlobAttribute(filename, FileAccess.Write)))
                {
                    writer.Write(JsonConvert.SerializeObject(a_object));
                }
