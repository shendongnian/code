    public override string Read()
    {
        var wrapped = WrappedReader.Read();
        if (!string.IsNullOrEmpty(wrapped))
            wrapped += " ,";
        return wrapped + "type";
    }
