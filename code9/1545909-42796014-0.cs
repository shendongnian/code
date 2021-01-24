    public async Task<IReadOnlyCollection<SomeTypeDTO>> aAssembleResponse<T>(T aSomeContext)
    {
        var _SomeContext = (SomeContext)Convert.ChangeType(aSomeContext, typeof(SomeContext));
        return _SomeContext;     
    }
