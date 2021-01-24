    using System.IO;
    using System.Net;
    
    NetworkCredential theNetworkCredential = new 
    NetworkCredential(@"domain\username", "password");
    CredentialCache theNetCache = new CredentialCache();
    theNetCache.Add(new Uri(@"\\computer"), "Basic", theNetworkCredential);
    string[] theFolders = Directory.GetDirectories(@"\\computer\share");
