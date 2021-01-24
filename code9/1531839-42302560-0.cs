    private string _presentWorkingDirectory;
    private string PresentWorkingDirectory
    {
        get
        {
            if (!string.IsNullOrEmpty(_presentWorkingDirectory))
                return _presentWorkingDirectory;
            var assembly = Assembly.GetExecutingAssembly();
            var codebase = new Uri(assembly.CodeBase);
            var filePath = codebase.LocalPath;
            var path = Directory.GetParent(filePath);
            _presentWorkingDirectory = path.ToString();
            return _presentWorkingDirectory;
        }
    }
