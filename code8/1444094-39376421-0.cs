    private Collection<PSObject> RunScript(string scriptText)
        {
            // create Powershell runspace 
            Runspace runspace = RunspaceFactory.CreateRunspace();
            // open it 
            runspace.Open();
            runspace.SessionStateProxy.SetVariable("ComputerName", CompnameInput.Text);
            runspace.SessionStateProxy.SetVariable("user", UserNameInput.Text);
            // create a pipeline and feed it the script text 
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);
            // add an extra command to transform the script output objects into nicely formatted strings 
            // remove this line to get the actual objects that the script returns. For example, the script 
            // "Get-Process" returns a collection of System.Diagnostics.Process instances. 
          //  pipeline.Commands.Add("Out-String");
            // execute the script 
            Collection<PSObject> results = pipeline.Invoke();
            // close the runspace 
            runspace.Close();
            
            return results;
}
