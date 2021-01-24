    private DGCaseBookings myItem = new DGCaseBookings();
    public DGCaseBookings MyItem
    {
        get { return myItem; }
        set
        {
            SetProperty(ref myItem, value, () => MyItem);
        }
    }
