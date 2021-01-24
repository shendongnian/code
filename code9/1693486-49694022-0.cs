    // execute a SVN command and fetch the output as a string
    private string ExecuteSVNCommandWithOutput(string SVNCommand)
    {
        string output = "";
        try
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = "cmd";
                p.StartInfo.Arguments = "/c " + SVNCommand;
                p.StartInfo.RedirectStandardOutput = true; 
                p.Start();
                output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
        }
        // unexpected error
        catch (Exception ex)
        {
            output = ex.ToString();
        }
        return output;
    }
