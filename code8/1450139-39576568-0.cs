    static System.IO.FileStream fs;
    private static void GetFileStream()
    {
        if(fs == null) fs = System.IO.File.Open(....);
        return fs;
    }
    public Enumarable<string> GetLines()
    {
        // return an enumerator that uses the result of GetFileStream() and 
        // advances the file pointer. All Enumerables returned by this method
        // will return unique lines from the same file
    }
