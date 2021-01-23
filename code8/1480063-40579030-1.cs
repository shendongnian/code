    static void Main(string[] args)
    {
        Class[] classInstances =
        {
            new Class("A"),
            new Class("B"),
            new Class("C"),
        };
        foreach (Class c in classInstances)
        {
            c.Event += All_Event;
        }
        foreach (Class c in classInstances)
        {
            c.RaiseEvent();
        }
    }
    static void All_Event(object sender, EventArgs e)
    {
        switch (((Class)sender).Name)
        {
            case "A":
                A_Event(sender, e);
                break;
            case "B":
                B_Event(sender, e);
                break;
            case "C":
                C_Event(sender, e);
                break;
        }
    }
