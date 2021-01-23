    public static void WriteLog(string LogStr)
    {
    	try
    	{
    		string LogFilePath = Server.MapPath("Logs.txt");
    		FileStream fs = new FileStream(LogFilePath, FileMode.Create | FileMode.Append);
    		StreamWriter sw = new StreamWriter(fs);
    		sw.WriteLine(DateTime.Now.ToShortDateString() + " | " + DateTime.Now.TimeOfDay + "=|" + LogStr);
    		sw.Close();
    		fs.Close();
    	}
    	catch (Exception e)
    	{
    	
    	}
    }
