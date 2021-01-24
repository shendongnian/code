    public static void Main()
    {
    	Process myProcess = new Process();
    
    	try
    	{
    		myProcess.StartInfo.UseShellExecute = false;
    		myProcess.StartInfo.FileName = "C:\\Windows\\System32\\robocopy.exe Source Destination";
    		myProcess.StartInfo.CreateNoWindow = true;
    		myProcess.Start();
    	}
    	catch (Exception e)
    	{
    		Console.WriteLine(e.Message);
    	}
    }
