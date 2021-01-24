    private static string[] Names = new[] { "KK", "AB", "BC", "DD", "FV", "ER", "PP", "WW" };
 
    //...
    var list =  mail.Package.
               Select(p => new {Package = p, Index = Array.IndexOf(Names, p.Name)}).
               OrderBy(p => p.Index).
               Select(p => p.Package).ToList(); 
