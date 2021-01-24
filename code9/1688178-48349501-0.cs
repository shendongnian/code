    if (num == S.Top())
    {
        while (!Temp.IsEmpty()) // Infinite loop, Temp is never empty
        {
            S.Push(Temp.Top()); // Because of infinite loop, S is just going to fill up memory
        }
        
        //...
