    public IFormFile ReturnFormFile(FileStreamResult result)
    {
        var ms = new MemoryStream();
        try
        {
            result.FileStream.CopyTo(ms);
            return new FormFile(ms, 0, ms.Length);
        }
        finally
        {
            ms.Dispose();
        }
    }
