        [Import]
        private IVsPackageInstallerEvents packageInstallerEvents;
        [Import]
        private IVsPackageInstallerProjectEvents packageInstallerProjectEvents;
        private string currentBatchId;
        private Dictionary<string, string> packagesMetadata;
        public void BindNuGetPackageEvents()
        {
            packageInstallerProjectEvents.BatchStart += (projectMetadata) =>
            {
                // preserve current batch id or project name to compare with batch end event
                currentBatchId = projectMetadata.BatchId;
                Console.WriteLine("Current Project Name : " + projectMetadata.ProjectName);
            };
            packageInstallerEvents.PackageInstalled += (metadata) =>
            {
                // package being insalled in current project
                // Save package metadata to use at batch end event
                packagesMetadata.Add(metadata.Id, "installed");
            };
            packageInstallerEvents.PackageUninstalled += (metadata) =>
            {
                // package being uninstalled in current project
                // Save package metadata to use at batch end event
                packagesMetadata.Add(metadata.Id, "uninstalled");
            };
            packageInstallerProjectEvents.BatchEnd += (projectMetadata) =>
            {
                if (currentBatchId == projectMetadata.BatchId)
                {
                    // Now you can use your packages metadata saved during packageinstalled or packageuninstalled events
                    foreach (var packageName in packagesMetadata.Keys)
                    {
                        Console.WriteLine(string.Format("Package {0} was {1}", packageName, packagesMetadata[packageName]));
                    }
                }
            };
        }
