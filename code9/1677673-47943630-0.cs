    // Work Around Begin Here
    string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    // Check if we are in temp dir
    if (assemblyFolder.Contains("Temporary ASP.NET Files"))
    {
        DirectoryInfo dir = new DirectoryInfo(assemblyFolder);
        // Go up 2 dirs
        DirectoryInfo top = dir.Parent.Parent;
        DirectoryInfo[] dirs = top.GetDirectories();
        foreach (DirectoryInfo child in dirs)
        {
            DirectoryInfo[] dirs2 = child.GetDirectories();
            foreach (DirectoryInfo child2 in dirs2)
            {
                // Find out if this is the Rep
                if (File.Exists(child2.FullName + "\\ThirdParty.Representation.dll"))
                {
                    
                    // Look to see if resource folder is there
                    if (!Directory.Exists(child2.FullName + "\\Resources"))
                    {
                            child2.CreateSubdirectory("Resources");
                    }
                    DirectoryInfo resDir = new DirectoryInfo(child2.FullName + "\\Resources");
                    if (File.Exists(resourceDir + "RepresentationSystem.xml"))
                    {
                        if(!File.Exists(resDir.FullName + "\\RepresentationSystem.xml"))
                        {
                            File.Copy(resourceDir + "RepresentationSystem.xml", resDir.FullName + "\\RepresentationSystem.xml");
                        }
                    }
                    if (File.Exists(resourceDir + "UnitSystem.xml"))
                    {
                        if (!File.Exists(resDir.FullName + "\\UnitSystem.xml"))
                        {
                            File.Copy(resourceDir + "UnitSystem.xml", resDir.FullName + "\\UnitSystem.xml");
                        }
                    }
                }
            }
        }
    }
