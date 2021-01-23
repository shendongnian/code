    var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(fileName));
        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        {
            FileName = "Foo.txt"
        };
        content.Add(fileContent);
