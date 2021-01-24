        public static IReadOnlyList<CodeFile> ReadSolution(string path)
        {
            List<CodeFile> codes = new List<CodeFile>();
            var dirName = System.IO.Path.GetDirectoryName(path);
            var dir = new DirectoryInfo(dirName);
            var csProjFiles = dir.EnumerateFiles("*.csproj", SearchOption.AllDirectories);
            foreach(var csProjFile in csProjFiles)
            {
                var csProjPath = csProjFile.Directory.FullName;
                using (var fs = new FileStream(csProjFile.FullName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = XmlReader.Create(fs))
                    {
                        while(reader.Read())
                        {
                            if(reader.Name.Equals("Compile", StringComparison.OrdinalIgnoreCase))
                            {
                                var fn = reader["Include"];
                                var filePath = Path.Combine(csProjPath, fn);
                                var text = File.ReadAllText(filePath);
                                codes.Add(new CodeFile(fn,text));
                            }
                        }
                    }
                }
            }
            return codes;
        }
