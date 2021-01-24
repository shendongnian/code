    public static void ImportBuildDefinition(IBuildServer buildServer, string projectName, string filePath, string newBuildName, string sourceProvider)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File does not exist!", filePath);
            Console.WriteLine($"Importing build definition from file '{filePath}' to '{projectName}' project.");
            var json = File.ReadAllText(filePath);
            var buildDef = JsonConvert.DeserializeObject<BuildDefinitionModel>(json);
            var newBuildDefinition = CloneBuildDefinition(buildServer, buildDef, newBuildName, projectName, sourceProvider);
            Console.WriteLine($"Build definition '{buildDef.Name}' succesfully imported to '{projectName}' project.");
        }
        static IBuildDefinition CloneBuildDefinition(IBuildServer buildServer, BuildDefinitionModel buildDefinitionSource, string newBuildName, string projectName, string sourceProvider)
        {
            var buildDefinitionClone = buildServer.CreateBuildDefinition(projectName);
            buildDefinitionClone.BuildController = GetBuildController(buildServer, "");
            buildDefinitionClone.Process = buildServer.QueryProcessTemplates(buildDefinitionSource.TeamProject).FirstOrDefault(c=> c.Id == buildDefinitionSource.Process.Id);
            buildDefinitionClone.ProcessParameters = buildDefinitionSource.ProcessParameters;
            buildDefinitionClone.TriggerType = buildDefinitionSource.TriggerType;
            buildDefinitionClone.ContinuousIntegrationQuietPeriod = buildDefinitionSource.ContinuousIntegrationQuietPeriod;
            buildDefinitionClone.DefaultDropLocation = buildDefinitionSource.DefaultDropLocation;
            buildDefinitionClone.Description = buildDefinitionSource.Description;
            buildDefinitionClone.QueueStatus = Microsoft.TeamFoundation.Build.Client.DefinitionQueueStatus.Enabled;
            buildDefinitionClone.BatchSize = buildDefinitionSource.BatchSize;
            buildDefinitionClone.Name = newBuildName;
            foreach (var schedule in buildDefinitionSource.Schedules)
            {
                var newSchedule = buildDefinitionClone.AddSchedule();
                newSchedule.DaysToBuild = schedule.DaysToBuild;
                newSchedule.StartTime = schedule.StartTime;
                newSchedule.TimeZone = schedule.TimeZone;
            }
            foreach (var mapping in buildDefinitionSource.Workspace.Mappings)
            {
                buildDefinitionClone.Workspace.AddMapping(
                    mapping.ServerItem, mapping.LocalItem, mapping.MappingType, mapping.Depth);
            }
            buildDefinitionClone.RetentionPolicyList.Clear();
            foreach (var policy in buildDefinitionSource.RetentionPolicyList)
            {
                buildDefinitionClone.AddRetentionPolicy(
                    policy.BuildReason, policy.BuildStatus, policy.NumberToKeep, policy.DeleteOptions);
            }
            //Source Provider
            IBuildDefinitionSourceProvider provider = buildDefinitionClone.CreateInitialSourceProvider(sourceProvider);
            if (sourceProvider == VersionControlType.TFGIT.ToString())
            {
                provider.Fields["RepositoryName"] = "Git";
            }
            buildDefinitionClone.SetSourceProvider(provider);
            buildDefinitionClone.Save();
            return buildDefinitionClone;
        }
        private static IBuildController GetBuildController(IBuildServer buildServer, string buildController)
        {
            if (string.IsNullOrEmpty(buildController))
                return buildServer.QueryBuildControllers(false).Where(c=> c.Status == ControllerStatus.Available).First();
            return buildServer.GetBuildController(buildController);
        }
