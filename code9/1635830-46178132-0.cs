    void Main()
    {
    	Process p = Process.GetProcessById(12008);
    	var originalAffinity = p.ProcessorAffinity;
    	Console.WriteLine("Original affinity: " + originalAffinity);
    	p.ProcessorAffinity = (IntPtr)0x0001;
    	Console.WriteLine("Current affinity: " + p.ProcessorAffinity);
    	p.ProcessorAffinity = originalAffinity;
    	Console.WriteLine("Final affinity: " + p.ProcessorAffinity);   	
    }
