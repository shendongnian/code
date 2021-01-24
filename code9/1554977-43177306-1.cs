    static public Assembly LoadCode(string scriptText, bool debugBuild, params string[] refAssemblies)
    {
        string tempFile =  System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() +".cs";        
        try
        {
            using (StreamWriter sw = new StreamWriter(tempFile))
                sw.Write(scriptText);        
            return LoadWithConfig(scriptFile, null, debugBuild, CSScript.GlobalSettings, "-warn:0", refAssemblies);
        }
        finally
        {
            if (!debugBuild)
            {
                //delete temp file
            }
        }
    }
