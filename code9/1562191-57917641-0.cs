  using EnvDTE;
  using EnvDTE80;
  using Microsoft.VisualStudio.Shell;
  var dte = Package.GetGlobalService(typeof(_DTE)) as DTE2;
1. To programmatically open a **solution**:
   dte.Solution.Open(path);
2. To programmatically open a **project**:
  dte.ExecuteCommand("File.OpenProject", path);
3. To programmatically open a **folder**:
  dte.ExecuteCommand("File.OpenFolder", path);
4. To programmatically open a **file**:
  dte.ExecuteCommand("File.OpenFile", path);
I hope that helps someone.
