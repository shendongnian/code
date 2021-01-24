         public class NugetSource
            {
                public string Name { get; set; }
                public string Value { get; set; }
            }
    public class MyAppVersion
        {
            public double Id { get; set; }
            public ObservableCollection<Dependency> Dependencies { get; set; }
    
            public MyAppVersion()
            {
                Dependencies = new ObservableCollection<Dependency>();
            }
        }
     
    
    public class Dependency : ReactiveObject
        {
            public Dependency()
            {
                AvailableVersions = new List<SemanticVersion>();
            }
    
            private SemanticVersion _version;
            private string _name;
            private List<SemanticVersion> _availableVersions;
    
            [JsonProperty]
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    this.RaiseAndSetIfChanged(ref _name, value);
                }
            }
    
            [JsonProperty]
            public SemanticVersion Version
            {
                get
                {
                    return _version;
                }
                set
                {
                    this.RaiseAndSetIfChanged(ref _version, value);
                }
            }
    
            [JsonIgnore]
            public List<SemanticVersion> AvailableVersions
            {
                get
                {
                    return _availableVersions;
                }
                set
                {
                    this.RaiseAndSetIfChanged(ref _availableVersions, value);
                }
            }
    
            public override string ToString()
            {
                return $"Name: {Name}, Version: {Version}";
            }
        }
    public class NugetUpdater : INugetUpdater
        {
            private readonly List<IPackageRepository> _supportedRepositories;
    
            public NugetUpdater()
            {
                _supportedRepositories = GetSources().Select(x => PackageRepositoryFactory.Default.CreateRepository(x.Value)).ToList();
            }
    
    
    
            public NugetSource[] GetSources()
            {
    
                var sources = new[] {
                    new NugetSource() {Name = nameof(AppPaths.Dev),Value = AppPaths.Dev} ,
                    new NugetSource() {Name = nameof(AppPaths.Uat),Value = AppPaths.Uat} ,
                    new NugetSource() {Name = nameof(AppPaths.ThirdParty),Value = AppPaths.ThirdParty} ,
                };
    
                return sources;
            }
    
            public List<SemanticVersion> GetVersions(IEnumerable<string> feedUrls, string packageId)
            {
                var versions = new List<SemanticVersion>();
                var repos = GetRepositories(feedUrls);
    
                foreach (var currentRepo in repos)
                {
                    var packages = currentRepo.FindPackagesById(packageId).ToList();
                    versions.AddRange(packages.Select(x => x.Version));
                }
    
                return versions;
            }
    
            public SemanticVersion GetLatestVersion(IEnumerable<string> feedUrls, string packageId)
            {
                var versions = GetVersions(feedUrls, packageId);
                return versions.Any() ? versions.Max() : null;
            }
    
    
            public SemanticVersion GetLatestVersion(string feedUrl, string packageId)
            {
                return GetLatestVersion(new[] { feedUrl }, packageId);
            }
    
    
            public List<SemanticVersion> GetVersions(string feedUrl, string packageId)
            {
                return GetVersions(new[] { feedUrl }, packageId);
            }
    
            public List<Dependency> GetSolutionDependencies(string baseDir)
            {
                return Directory.EnumerateFiles(baseDir, "project.json", SearchOption.AllDirectories)
                    .Select(File.ReadAllText)
                    .Select(JObject.Parse)
                    .Select(GetDependencies)
                    .SelectMany(x => x)
                    .DistinctBy(x => x.Name)
                    .ToList();
            }
    
    
    
            private List<IPackageRepository> GetRepositories(IEnumerable<string> feedUrls)
            {
                return _supportedRepositories.Where(x => feedUrls.Contains(x.Source)).ToList();
            }
    
            public void Update(string baseDir, MyAppVersion version)
            {
                IEnumerable<string> jsonFiles = Directory.EnumerateFiles(baseDir, "project.json", SearchOption.AllDirectories).ToList();
    
                foreach (var projectJsonPath in jsonFiles)
                {
                    var content = File.ReadAllText(projectJsonPath);
                    JObject json = JObject.Parse(content);
                    var projectDependencies = GetDependencies(json);
    
                    if (!projectDependencies.Any())
                        continue;
    
                    var projectDepNames = projectDependencies.Select(x => x.Name).ToList();
                    var toUpdateDependencies = version.Dependencies.Where(x => projectDepNames.Contains(x.Name)).ToList();
    
                    if (toUpdateDependencies.Count != projectDependencies.Count)
                        throw new Exception("Dependencies count is not equal. Something went wrong");
    
                    var dependenciesPairs = toUpdateDependencies.OrderBy(x => x.Name).Zip(projectDependencies.OrderBy(x => x.Name), (x, y) => new { ToUpdate = x, Project = y }).ToList();
    
    
                    bool anyChanged = false;
    
                    foreach (var dependencyPair in dependenciesPairs)
                    {
                        if (dependencyPair.Project.Version != dependencyPair.ToUpdate.Version)
                        {
                            anyChanged = true;
                            dependencyPair.Project.Version = dependencyPair.ToUpdate.Version;
                        }
                    }
    
                    if (anyChanged)
                    {
                        JObject obj = new JObject(projectDependencies.Select(x => new JProperty(x.Name, x.Version.ToNormalizedString())));
                        json["dependencies"] = obj;
                        File.WriteAllText(projectJsonPath, json.ToString(Formatting.Indented));
                    }
                }
            }
    
            private static List<Dependency> GetDependencies(JObject json)
            {
                JObject dependenciesObject = (JObject)json["dependencies"];
    
                var dependencies = dependenciesObject.Properties().Select(x => new Dependency
                {
                    Name = x.Name,
                    Version = SemanticVersion.Parse(x.Value.Value<string>())
                }).ToList();
    
                return dependencies;
            }
        }
