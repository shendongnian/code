    foreach(BRIDGE bridge in bridges)
    {
        //Context.BRIDGE.Add(bridge); remove this line
        //Context.BRIDGE.Attach(bridge); remove this line
        bridge.USER.Add(user);    
    }
    
    Context.BRIDGE.AddRange(bridges);    
    Context.SaveChanges();
