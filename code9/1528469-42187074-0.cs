    private ICommand myThing;
    public ICommand MyThing
    {
        get
        {
            if (myThing == null)
            {
                myThing = new MyCommand(myArgs);
            }
            return myThing;
        }
    }
