    using System.Diagnostics;
    var provider = new PhysicalFileProvider(applicationRoot);
    // the applicationRoot contents
    var contents = provider.GetDirectoryContents("");
    // a file under applicationRoot
    var fileInfo = provider.GetFileInfo("wwwroot/js/site.js");
    // version information
    var myFileVersionInfo = FileVersionInfo.GetVersionInfo(fileInfo.PhysicalPath);
