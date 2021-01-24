        //Error checking logic to ensure zip file exists and is valid...
        using (var zip = ZipFile.OpenRead(zipPath))
        using (var entry = zip.GetEntry(parts[1]))
        {
            //Error checking logic to ensure inside file exists within zip file.
            MemoryStream stream = new MemoryStream();
            entry.Open().CopyTo(stream);
            stream.Seek(0, SeekOrigin.Begin); 
            return stream;
        }
