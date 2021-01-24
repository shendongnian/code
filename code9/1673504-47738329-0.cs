    public void ValidateFiles(string[] args)
    {
        var validRar = (from item in args
            where Path.GetExtension(item) == ".rar" ||
                  Path.GetExtension(item) == ".r00"
            select item).ToArray();
        var validZip = (from item in args
            where Path.GetExtension(item) == ".zip"
            select item).ToArray();
    //do some more stuff 
    }
