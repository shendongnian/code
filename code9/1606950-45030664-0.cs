    private int _contactGroup;
    public int ContactGroup
    {
        get { return _contactGroup; }
        set
        {
            _contactGroup = value;
            ListContactGroups();
        }
    }
