    foreach (var dteProject in dte.Solution.Projects.OfType<Project>())
    {
        // You can edit the project through an object of Microsoft.Build.Evaluation.Project 
        var buildProject = ProjectCollection.GlobalProjectCollection.GetLoadedProjects(dteProject.FullName).First();
        foreach (var item in buildProject.Items.Where(obj => obj.ItemType == "Reference"))
        {
            var newPath = SomeMethod(item.GetMetadata("HintPath"));
                
            item.SetMetadataValue("HintPath", newPath);
        }
        // But you have to save through an object of EnvDTE.Project
        dteProject.Save();
    }
