    public static bool DoStuff(Parent parent)
    {
        if (parent.GetType() == typeof(Child1))
        {
            Child1 child = parent as Child1;
            DoStuffChild1(child);
        }
        else if (parent.GetType() == typeof(Child2))
        {
            Child2 child = parent as Child2;
            DoStuffChild2(child);
        }
        else if (parent.GetType() == typeof(Child3))
        {
            Child3 child = parent as Child3;
            DoStuffChild3(child);
        }
        else
        {
            HandleError();
        }
    }
