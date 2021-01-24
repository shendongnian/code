    // Collection of tabs.
    private List<TabData> _tabList;
    // Property to hold the collection of tabs.
    // Set the Personalizable attribute to true, 
    // to allow for personalization of tabs by users.
    [Personalizable(true)]
    public List<TabData> TabList { 
        get
        {
            if (this._tabList == null)
            {
                // Return an empty collection if null.
                this._tabList = new List<TabData>();
            }
            return this._tabList;
        }            
        set
        {
            this._tabList = value;
        } 
    }   
