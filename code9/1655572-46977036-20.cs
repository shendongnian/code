    public async Task<FileResult> Download()
    {
        string fileName = "foo.csv"
        byte[] fileBytes = ... ;
        return File(fileBytes, "text/csv", fileName); // this is the key!
    }
