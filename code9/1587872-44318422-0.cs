    static void Main(string[] args)
    {
        GC.TryStartNoGCRegion(1000 * 10000);
        //Allocate more than declared
        for (int i = 0; i < 1100; i++)
        {
            var arr = new byte[10000];
        }
        //Line below throws as it should
        try
        {
            System.GC.EndNoGCRegion();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        //Not NoGCRegion
        Console.WriteLine(System.Runtime.GCSettings.LatencyMode);
        //Throws with "The NoGCRegion mode was already in progress
        Console.WriteLine(GC.TryStartNoGCRegion(1000 * 10000));
        Console.ReadLine();
    }
