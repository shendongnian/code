    public IList<IReaderInfo> GetReaders
    {
        var readers = new List<ReaderInfo>();
        var Ireaders = someobject.Getreaders();// Returns the list of IReaderInfo.
        return Ireaders;
    }
