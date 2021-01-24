    int i = 0;
    while ( i < 100 )
        try
        {
            while( i < 100 )
            {
                DoSomethingThatMaybeThrowException();
                i++;
            }
        }
        catch ( Exception )
        {
            // ignore or handle
            i++;
        }
