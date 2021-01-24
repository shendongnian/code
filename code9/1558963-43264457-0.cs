    public MyTopItems
    {
        get
        {
            return myCollection.Take(3);
        }
    }
