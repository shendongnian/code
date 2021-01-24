    DTE2 dte = (DTE2)this.ServiceProvider.GetService(typeof(DTE));
                EnvDTE.Project currentProject = dte.Solution.Projects.Item(1);
    
                // Create a new Project object.
                Microsoft.Build.BuildEngine.Project project = new Microsoft.Build.BuildEngine.Project();
    
                project.Load(currentProject.FullName);
    
                foreach (BuildItemGroup ig in project.ItemGroups)
                {
                    //var items = ig.ToArray();
    
                    foreach (BuildItem item in ig.ToArray())
                    {
                        if (item.Include == "ClassLibrary1")
                        {
                            item.Include = "Utils";
                            item.SetMetadata("HintPath", @"C:\relativePath\Utils.dll");
                        }
                    }
                }
                project.Save(currentProject.FullName);
