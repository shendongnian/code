    static public Assembly LoadCode(string scriptText, bool debugBuild, params string[] refAssemblies)
    {
        string tempFile = CSExecutor.GetScriptTempFile()+".cs";
        
        try
        {
            using (StreamWriter sw = new StreamWriter(tempFile))
                sw.Write(scriptText);        
            return CompileWithConfig(scriptFile, null, debugBuild, CSScript.GlobalSettings, "-warn:0 -co:-warnaserror-", refAssemblies);
        }
        finally
        {
            if (!debugBuild)
            {
                //delete temp file
            }
        }
    }
