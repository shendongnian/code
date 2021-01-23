    public CompileObjectException(ICustomObject ownerCustomObject, string message, Exception innerException = null)
        : base(message, innerException)
    {
        _ownerCustomObject = ownerCustomObject;
    }
