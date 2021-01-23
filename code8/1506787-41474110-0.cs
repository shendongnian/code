    public static void callInsertProgram(string xml, string program)
    {
        try
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = @"C:\Rubixx\runProgress.exe";
                p.StartInfo.WorkingDirectory = @"C:\Rubixx";
                // stop windows from appearing on the server
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                // set the arguments for running. The program name and xml are passed in as arguments
                // wrapped in escaping "\" to stop spaces from being treated as a separator
                p.StartInfo.Arguments = "\"" + program + "," + xml + "\"";
                p.Start();
                // ADDED
                p.WaitForExit(60000);
            }
        }
        catch (Exception e)
        {
            throw new OpenHousingException(e.Message.ToString());
        }
    }
