    foreach (EntityBaseClass item in list)
    {
        if (item.GetType() == typeof(Class1))
        {
            Class1 cl1 = (Class1)item;
            //Your code
        }
        else
        {
            Class2 cl2 = (Class2)item;
            //Your code
        }
    }
