    using (var runspace = RunspaceFactory.CreateRunspace())
    {
        try
        {
            var script = File.ReadAllText("MyScript.ps1");
            runspace.Open();
            var ps = PowerShell.Create();
            ps.Runspace = runspace;
            ps.AddScript(script);
            ps.Invoke();
            ps.AddCommand("MyFunction").AddParameters(new Dictionary<string, string>
            {
                { "Param1" , value1},
                { "Param2", value2},
                { "Param3", value3},            
            });
    
            foreach (var result in ps.Invoke())
            {
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
