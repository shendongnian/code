    var org = message.Current.org_name;
               
    var found = account.Entities.Any( // does any entity contain org ?
        x => x.Attributes["name"]     // Get Attribute
            .ToString()               // Convert it to string if needed
            .Contains(org));          
              
    if (found)
    {
        c.CreateAccount(message);
    }
    
    c.CreateOpportunity(message);
