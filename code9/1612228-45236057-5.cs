    // using System.IO;
    // using Microsoft.AspNetCore.Hosting;
    // IHostingEnvironment env
    ...
    var fileProvider = env.WebRootFileProvider;
    // here you define only subpath
    var fileInfo = fileProvider.GetFileInfo("keywords\keywords.json"); 
    
    var fileStream = fileInfo.CreateReadStream();
    
    using (var reader = new StreamReader(fileStream))
    {
        string data = reader.ReadToEnd();
    }
