    private Lazy<object> _MemberLazy = new Lazy<object>(LoadMember);
    public object MemberValue
    {
        get
        {
            return _MemberLazy.Value;
        }
    }
