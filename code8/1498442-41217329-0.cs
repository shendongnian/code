        DTE2 dte = (DTE2)this.ServiceProvider.GetService(typeof(DTE));
                Solution2 solution = (Solution2)dte.Solution;
    
                foreach (Project p in solution.Projects)
                {
    
                    string[] projectName = p.FullName.Split('.');
    
                    if (projectName.Length > 1)
                    {
                       string fileExt = projectName[projectName.Length-1];
    
                        if (fileExt == "vcxproj")
                        {
                            //is c/c++ porject
                        }
                    }
    }
