    private List<SoftwareDefEntity> _swEntities;
    public List<SoftwareDefEntity> SWentities
    {
        get { return _swEntities; }
        set { _swEntities = value; RaisePropertyChanged(); }
    }
