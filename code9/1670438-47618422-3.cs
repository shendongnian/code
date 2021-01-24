    var runningsection = 0;
    const string dhcp = "(DHCP)";
    var foundDevicesIP = from l in lines
        let section = l.StartsWith("----") ? 
                      runningsection++:
                      runningsection                             // grouping for sections
        where l.StartsWith("Created at") || l.Contains(dhcp)     // which lines to keep
        group new {                                              // type with line and linetype properties
            line =  l.Split('|')[1].Replace(dhcp,String.Empty),  // parse/shape the value
            linetype = l.Contains(dhcp)?1:2                      // was it an IP address (1) or Created at (2)
        } by section into agg                                    // group the lines beloning to the same section
        where agg.Count() > 1                                    // which groups have 2 or more lines
        select new
            {   
                IP = agg.First( l => l.linetype == 1).line,      // the first object with linetype 1 is the IP
                Created = agg.First( l => l.linetype == 2).line  // the first object with linetype 2 is the creation date
            };
    
        
        var list = new List<string>();
        foreach(var deviceIP in foundDevicesIP) 
        {
            list.Add(String.Format("IP: {0} , # {1} #", deviceIP.IP, deviceIP.Created));
        }
