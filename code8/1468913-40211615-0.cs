    var currentDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
    
    var parentDirectory = System.IO.Directory.GetParent(currentDirectoryPath);
    while (!string.Equals(parentDirectory.Name, "Atrias.WebAutomationTesting", StringComparison.CurrentCultureIgnoreCase))
    {
        parentDirectory = parentDirectory.Parent;
        if (parentDirectory == null)
            break;
    }
    
    if (parentDirectory != null)
    {
        var targetDirectory = parentDirectory.FullName + "\\Test";
        MessageBox.Show(targetDirectory);
    }
