    public void DoSomething(Parent P)
    {
        // P is 'Child1' or 'Child2'
        switch(p)
        {
            case is Child1 child1:
            {
                ...
                break;
            }
            case is Child2 child2:
            {
                ...
                break;
            }
        }        
    }
