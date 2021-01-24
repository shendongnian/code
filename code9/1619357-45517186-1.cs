    using (Runspace runSpace = RunspaceFactory.CreateRunspace())
    {
        runSpace.Open();
        using (Pipeline pipeline = runSpace.CreatePipeline())
        {
            Command importStartLayout = new Command("Import-StartLayout");
            importStartLayout.Parameters.Add("LayoutPath", "C:\\StartMenu.xml");
            importStartLayout.Parameters.Add("MountPath", "C:\\");
            pipeline.Commands.Add(importStartLayout);
            Collection<PSObject> resultsObjects = pipeline.Invoke();
            StringBuilder resultString = new StringBuilder();
            foreach (PSObject obj in resultsObjects)
            {
                resultString.AppendLine(obj.ToString());
            }
        }
    }
