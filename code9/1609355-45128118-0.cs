    public FileResult image(string id)
        {
            var dir = @"\\SERVERNAME\upload\";
            var path = Path.Combine(dir, id);
            string contentType = MimeMapping.GetMimeMapping(path);
            return base.File(path, contentType);
        }
