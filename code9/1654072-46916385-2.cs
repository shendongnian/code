    if (requestContext.HttpContext.Request.Files.Count > 0)
    {
        var finalDir = "path/to/dir"
        foreach (HttpPostedFileBase file in requestContext.HttpContext.Request.Files)
        {
            var decodedFileName = System.Net.WebUtility.HtmlDecode(file.FileName);
            try
            {
                // Will not overwrite if the destination file already exists.
                if(filename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                    throw new Exception('invalid name');
                else
                    File.Copy(decodedFileName , Path.Combine(finalDir, Guid.NewGuid()));
            }
            // Catch exception if the file was already copied.
            catch (IOException copyError)
            {
                Console.WriteLine(copyError.Message);
            }
        }
    }
