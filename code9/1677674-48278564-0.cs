    private void CopyResourcesToTemporaryFolder()
    {
            // Work Around Begin Here
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string resourceDir = Path.Combine(FileUtils.WebProjectFolder, "Resources");
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
                        if (File.Exists(Path.Combine(child2.FullName, "AgGateway.ADAPT.Representation.DLL")))
                        {
                            // Look to see if resource folder is there
                            if (!Directory.Exists(Path.Combine(child2.FullName, "Resources")))
                            {
                                child2.CreateSubdirectory("Resources");
                            }
                            DirectoryInfo resDir = new DirectoryInfo(Path.Combine(child2.FullName, "Resources"));
                            if (File.Exists(Path.Combine(resourceDir, "RepresentationSystem.xml")))
                            {
                                if (!File.Exists(Path.Combine(resDir.FullName, "RepresentationSystem.xml")))
                                {
                                    File.Copy(Path.Combine(resourceDir, "RepresentationSystem.xml"), Path.Combine(resDir.FullName, "RepresentationSystem.xml"));
                                }
                            }
                            if (File.Exists(Path.Combine(resourceDir, "UnitSystem.xml")))
                            {
                                if (!File.Exists(Path.Combine(resDir.FullName, "UnitSystem.xml")))
                                {
                                    File.Copy(Path.Combine(resourceDir, "UnitSystem.xml"), Path.Combine(resDir.FullName, "UnitSystem.xml"));
                                }
                            }
                        }
                    }
                }
            }
        }
