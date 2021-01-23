    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
       switch (comboBox1.SelectedIndex)
       {
           case 1:
               ScriptName = @"c:\utils\Script2.ps1";
               break;
           case 2:
               ScriptName = @"c:\utils\Script3.ps1";
               break;
           default:
               ScriptName = @"c:\utils\Script1.ps1";
               break;
        }
    }
    
    private void bw_DoWork(object sender, EventArgs e)
    {
        var loadScript = LoadScript(ScriptName);
        if (string.IsNullOrWhiteSpace(loadScript)) return;
        RunScriptResult = RunScript(loadScript);
    }
    private static string LoadScript(string filename)
    {       
        if (!File.Exists(filename)) return "";
    
        var fileContents = new StringBuilder();
        var lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
           fileContents.Append(line + "\n");
        }
        return fileContents.ToString();
    }
    
    private static string RunScript(string scriptText)
    {         
        //should start from this line
        // create Powershell runspace
        Runspace runspace = RunspaceFactory.CreateRunspace();
        //bla bla bla bla
        return "something";
    }
