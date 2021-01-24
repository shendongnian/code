    Runspace runspace = RunspaceFactory.CreateRunspace();
    runspace.Open();
    Pipeline pipeline = runspace.CreatePipeline();
    pipeline.Commands.AddScript("Import-Module AzureADPreview -Force;");
    pipeline.Commands.AddScript("Connect-AzureAD");   
    var result = pipeline.Invoke();
