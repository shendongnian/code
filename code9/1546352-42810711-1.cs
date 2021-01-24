    public int WorkingItems
    {
        get { return workingItems; }
        set { workingItems = value; }
    }
    int workingItems= ComputerList.Where(x=> x.isWorking == true).Count();
