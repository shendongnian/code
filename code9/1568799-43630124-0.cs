        public static TeamProject CreateProject()
        {
           
            string projectName = "Sample project";
            string projectDescription = "Short description for my new project";
            string processName = "Agile";
            VssCredentials c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.WindowsCredential(new NetworkCredential("username", "password", "domain")));
            VssConnection connection = new VssConnection(new Uri("http://v-tinmo-12r2:8080/tfs/MyCollection"),c);
            // Setup version control properties
            Dictionary<string, string> versionControlProperties = new Dictionary<string, string>();
            versionControlProperties[TeamProjectCapabilitiesConstants.VersionControlCapabilityAttributeName] =
                SourceControlTypes.Git.ToString();
            // Setup process properties    
            ProcessHttpClient processClient = connection.GetClient<ProcessHttpClient>();
            Guid processId = processClient.GetProcessesAsync().Result.Find(process => { return process.Name.Equals(processName, StringComparison.InvariantCultureIgnoreCase); }).Id;
            Dictionary<string, string> processProperaties = new Dictionary<string, string>();
            processProperaties[TeamProjectCapabilitiesConstants.ProcessTemplateCapabilityTemplateTypeIdAttributeName] =
                processId.ToString();
            // Construct capabilities dictionary
            Dictionary<string, Dictionary<string, string>> capabilities = new Dictionary<string, Dictionary<string, string>>();
            capabilities[TeamProjectCapabilitiesConstants.VersionControlCapabilityName] =
                versionControlProperties;
            capabilities[TeamProjectCapabilitiesConstants.ProcessTemplateCapabilityName] =
                processProperaties;
            //Construct object containing properties needed for creating the project
           TeamProject projectCreateParameters = new TeamProject()
            {
                Name = projectName,
                Description = projectDescription,
                Capabilities = capabilities
            };
            // Get a client
            ProjectHttpClient projectClient = connection.GetClient<ProjectHttpClient>();
            TeamProject project = null;
            try
            {
                Console.WriteLine("Queuing project creation...");
                // Queue the project creation operation 
                // This returns an operation object that can be used to check the status of the creation
                OperationReference operation = projectClient.QueueCreateProject(projectCreateParameters).Result;
                // Check the operation status every 5 seconds (for up to 30 seconds)
                Operation completedOperation = WaitForLongRunningOperation(connection, operation.Id, 5, 30).Result;
                // Check if the operation succeeded (the project was created) or failed
                if (completedOperation.Status == OperationStatus.Succeeded)
                {
                    // Get the full details about the newly created project
                    project = projectClient.GetProject(
                        projectCreateParameters.Name,
                        includeCapabilities: true,
                        includeHistory: true).Result;
                    Console.WriteLine();
                    Console.WriteLine("Project created (ID: {0})", project.Id);
                    
                }
                else
                {
                    Console.WriteLine("Project creation operation failed: " + completedOperation.ResultMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during create project: ", ex.Message);
            }
            return project;
        }
        private static async Task<Operation> WaitForLongRunningOperation(VssConnection connection, Guid operationId, int interavalInSec = 5, int maxTimeInSeconds = 60, CancellationToken cancellationToken = default(CancellationToken))
        {
            OperationsHttpClient operationsClient = connection.GetClient<OperationsHttpClient>();
            DateTime expiration = DateTime.Now.AddSeconds(maxTimeInSeconds);
            int checkCount = 0;
            while (true)
            {
                Console.WriteLine(" Checking status ({0})... ", (checkCount++));
                Operation operation = await operationsClient.GetOperation(operationId, cancellationToken);
                if (!operation.Completed)
                {
                    Console.WriteLine("   Pausing {0} seconds", interavalInSec);
                    await Task.Delay(interavalInSec * 1000);
                    if (DateTime.Now > expiration)
                    {
                        throw new Exception(String.Format("Operation did not complete in {0} seconds.", maxTimeInSeconds));
                    }
                }
                else
                {
                    return operation;
                }
            }
        }
