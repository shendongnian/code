    bool bVal = true;
    Stopwatch sw = new Stopwatch();
    sw.Start();
    for(int i =0; i < amountOfTries; i++ )
    {
        int b = bVal ? 1 : 0;
    }
    sw.Stop();
    Console.WriteLine( $"Conditional operator: {sw.ElapsedTicks}t" );
    sw.Restart();
    for( int i = 0; i < amountOfTries; i++ )
    {
        int b = Convert.ToInt32(bVal);
    }
    sw.Stop();
    Console.WriteLine( $"Convert: {sw.ElapsedTicks}t" );
