    void Example1()
    {
        if (a)
        {
            if (b)
            {
                if (c)
                {
                    D();
                }
            }
            else
            {
                Y();
            }
        }
        else
        {
            X();
        }
    }
    void Example2()
    {
        if (!a) 
        {
            X();
            return;
        }
        if (!b)
        {
            Y();
            return;
        }
        if (!c) return;
        D();
    }
