    private EnvDTE.ProjectItem AddFileToSolution(string filePath)
    {
        var folder = CurrentProject.ProjectItems.AddFolder(Path.GetDirectoryName(filePath));
        var item = folder.ProjectItems.AddFromFileCopy(filePath);
        item.Properties.Item("BuildAction").Value = "None";
        // Setting attribute instead of property, becase property is not available
        SetProjectItemPropertyAsAttribute(CurrentProject, item, "CopyToOutputDirectory", "Always");
        // Reload project
        return item;
    }
    private void SetProjectItemPropertyAsAttribute(Project project, ProjectItem projectItem, string attributeName,
        string attributeValue)
    {
        IVsHierarchy hierarchy;
        ((IVsSolution)Package.GetGlobalService(typeof(SVsSolution)))
            .GetProjectOfUniqueName(project.UniqueName, out hierarchy);
        IVsBuildPropertyStorage buildPropertyStorage = hierarchy as IVsBuildPropertyStorage;
        if (buildPropertyStorage != null)
        {
            string fullPath = (string)projectItem.Properties.Item("FullPath").Value;
            uint itemId;
            hierarchy.ParseCanonicalName(fullPath, out itemId);
            buildPropertyStorage.SetItemAttribute(itemId, attributeName, attributeValue);
        }
    }
