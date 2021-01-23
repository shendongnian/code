    static void DumpLoadedAssemblies()
    {
    	var ads = AppDomain.CurrentDomain.GetAssemblies();
    	Console.WriteLine(ads.Length);
    	foreach (var ad in ads)
    	{
    		Console.WriteLine(ad.FullName);
            // maybe this can be helpful as well
    		foreach (var f in ad.GetFiles())
    			Console.WriteLine(f.Name);
    		Console.WriteLine("*******");
    	}
    }
