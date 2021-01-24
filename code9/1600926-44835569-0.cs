            RunspaceConfiguration runspaceConfig = RunspaceConfiguration.Create();
            Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfig);
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            string serverFqdn = "server";
            pipeline.Commands.AddScript(string.Format("$Session = New-PSSession -ConfigurationName Microsoft.Exchange -ConnectionUri http://{0}/PowerShell/ -Authentication Kerberos", serverFqdn));
            pipeline.Commands.AddScript("Import-PSSession $Session");
            pipeline.Commands.AddScript("Set-CASMailbox -Identity '" + userID + "' -OWAEnabled $true");
            pipeline.Commands.AddScript("Set-CASMailbox -Identity '" + userID + "' -ActiveSyncEnabled  $true");
            pipeline.Commands.Add("Out-String");
            Collection<PSObject> results = pipeline.Invoke();
            runspace.Close();
            if (pipeline.Error != null && pipeline.Error.Count > 0)
            {
                // failed
            }
            else
            {
                // Success
            }
            runspace.Dispose();
            pipeline.Dispose();
