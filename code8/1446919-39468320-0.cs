    private dynamic _source;
    public WrapperDynamic(dynamic source)
    {
        _source = source;
    }
    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {                        
        if (_source.CheckTheProperyExist(binder))
        {
            result = _source.GetProperty(binder);
            return true;
        }
        return false;
    }
