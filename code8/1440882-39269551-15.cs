    for (int i = 0; i < myCrate.Length; i++)
    {
        if (myCrate[i] != null)
        {
            Console.WriteLine( myCrate[i].Flavor  );
        }
        else
        {
            Console.WriteLine("Empty Space");
        }
    }
