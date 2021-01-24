    public static void Main(string[] args)
    {
        var gears = new GearCollection();
        //add gear instancs to gears
        var timer = new Timer(o => gears.Update(), null, 0, SOME_INTERVAL);            
    }
