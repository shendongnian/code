    string file = @"C:\Users\HP\Desktop\Date";
    ProcessStartInfo ProcessInfo;  
    foreach (string c in Directory.EnumerateFiles(file))
    {
        Console.WriteLine("Do you want to execute following file"+c);
        Console.WriteLine("\nPress 1. For Yes.");
        if(Console.ReadLine()=="1")
        {
	        Process p = new Process();
	        p.StartInfo.UseShellExecute = false;
	        p.StartInfo.FileName = c;
	        p.Start();
	        p.WaitForExit();
        }
    }
