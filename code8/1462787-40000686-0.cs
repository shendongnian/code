        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            var assemblies = new List<Assembly>();
            assemblies.AddRange(base.SelectAssemblies());
            //Load new ViewModels here
            string[] fileEntries = Directory.GetFiles(Directory.GetCurrentDirectory());
            assemblies.AddRange(from fileName in fileEntries
                                where fileName.Contains("ViewModels.dll")
                                select Assembly.LoadFile(fileName));
            assemblies.AddRange(from fileName in fileEntries
                                where fileName.Contains("Views.dll")
                                select Assembly.LoadFile(fileName));
            return assemblies;
        }
