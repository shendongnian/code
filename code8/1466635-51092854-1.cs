    Task("Generate-AssemblyInfo")
    	.Does(() => {
    		Information("Generate-AssemblyInfo started");
    
            // Read in solutioninfo
            var slnInfo = GetFiles(BuildParameters.SourceDirectoryPath + "/SolutionInfo.cs").FirstOrDefault();
            if(slnInfo == null) {
                Error("No solution info file could be found");
                return;
            }
            var slnData = System.IO.File.ReadAllLines(slnInfo.FullPath);
            //Debug(slnData);
    
            // Find template files
            var templateFiles = GetFiles("./**/AssemblyTemplate.cs");
            foreach(var file in templateFiles)
            {
                Information("Generating assemblyinfo from template: "+file);
                // Read AssemblyTemplate
                var templateData = System.IO.File.ReadAllLines(file.FullPath);
    
                // Replace template with Solutioninfo items
                var assemblyData = new StringBuilder();
                foreach(var line in templateData)
                {
                    var templateToken = "(\"TEMPLATE\")";
                    if(line.Contains(templateToken)) {
                        var attr = line.Substring(0, Math.Min(line.Length, line.IndexOf(templateToken)));
                        var replLine = slnData.Where(p => p.StartsWith(attr)).FirstOrDefault();
                        Debug("Replacing: "+attr+" in template "+file+" with "+replLine);
                        assemblyData.AppendLine(replLine);
                    } else {
                        assemblyData.AppendLine(line);
                    }
                }
    
                // Save AssemblyInfo
                var assemblyDataLines = assemblyData.ToString().Split(
                    new[] { System.Environment.NewLine },
                    StringSplitOptions.None
                );
                var assemblyInfoPath = new FilePath(file.GetDirectory() + "/AssemblyInfo.cs");
                System.IO.File.WriteAllLines(assemblyInfoPath.FullPath, assemblyDataLines);
            }
        });
