    using System.Reflection;
    using System.IO;
    // ...
    string exePath = Assembly.GetExecutingAssembly().Location;
    string exeFolder = Path.GetDirectoryName(exePath);
    string scriptPath = Path.Combine(exeFolder,"MyScript.ps1");
    var command = new Command(". " + scriptPath);
