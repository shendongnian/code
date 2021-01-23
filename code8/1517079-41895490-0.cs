    var CsprojDoc = new XmlDocument(); // My csproj
    IPackage packageInfos = GetNugetPackage(packageId, packageRepositoryUri);
    
    XmlNode referenceNode = CsprojDoc.CreateNode(XmlNodeType.Element, "Reference", XmlNamespaceValue);
    XmlAttribute includeAttribute = CsprojDoc.CreateAttribute("Include");
    
    var targetFwProfile = CsprojDoc.SelectSingleNode("//x:TargetFrameworkProfile", Nsmgr);
    string targetFrameworkProfile = string.Empty;
    if (!string.IsNullOrEmpty(targetFwProfile?.InnerXml))
    {
        targetFrameworkProfile = targetFwProfile.InnerXml;
    }
    
    var targetFwAttribute = GetTargetFrameworkFromCsproj();
    Regex p = new Regex(@"\d+(\.\d+)+");
    Match m = p.Match(targetFwAttribute.FrameworkName);
    Version targetFwVersion = Version.Parse(m.Value);
    
    // Get the package's assembly reference matching the target framework from the given '.csproj'.
    var assemblyReference =
        packageInfos.AssemblyReferences
            .Where(a => a.TargetFramework.Identifier.Equals(targetFwAttribute.FrameworkName.Split(',').First()))
            .Where(a => a.TargetFramework.Profile.Equals(targetFrameworkProfile))
            .Last(a => (a.TargetFramework.Version.Major.Equals(targetFwVersion.Major) && a.TargetFramework.Version.Minor.Equals(targetFwVersion.Minor)) ||
            a.TargetFramework.Version.Major.Equals(targetFwVersion.Major));
    
    DownloadNugetPackage(packageInfos.Id, packageRepositoryUri, packagesFolderPath, packageInfos.Version.ToFullString());
    
    string dllAbsolutePath = Path.GetFullPath($"{packagesFolderPath}\\{packageInfos.GetFullName().Replace(' ', '.')}\\{assemblyReference.Path}");
    var assemblyInfos = Assembly.LoadFile(dllAbsolutePath);
    
    includeAttribute.Value = $"{assemblyInfos.FullName}, processorArchitecture={processorArchitecture}";
    
    referenceNode.Attributes.Append(includeAttribute);
    
    XmlNode hintPathNode = CsprojDoc.CreateNode(XmlNodeType.Element, "HintPath", XmlNamespaceValue);
    XmlNode privateNode = CsprojDoc.CreateNode(XmlNodeType.Element, "Private", XmlNamespaceValue);
    
    hintPathNode.InnerXml = $"$(SolutionDir)\\packages\\{assemblyReference.Path}";
    privateNode.InnerXml = "True";
    
    referenceNode.AppendChild(hintPathNode);
    referenceNode.AppendChild(privateNode);
    
    parentNode.AppendChild(referenceNode);
