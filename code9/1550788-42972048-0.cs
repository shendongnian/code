    public FileResult ServeImage(string path)
    {
        var bytes = System.IO.File.ReadAllBytes(path);
        return File(bytes, "image/png");
    }
