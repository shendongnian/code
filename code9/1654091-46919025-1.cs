    Regex rgx = new Regex(@"RCLoad"); // RCLoad can be anywhere in the string.
    var controllers = ServiceController.GetServices(ServerName)
                                       .Where(sc => rgx.IsMatch( sc.Name )) 
                                       .ToList();
 
