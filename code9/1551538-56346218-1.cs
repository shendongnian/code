    if (!process.HasExited)
    {
        using (var streamWriter = process.StandardInput)
        {
    		// write your message here
    		var message = "q";
            streamWriter.WriteLine(message);
            streamWriter.Close();
        }
                   
        process.WaitForExit();
        process.Close();
        process.Dispose();
    }
