    public class Desk { public int ID; public string destinationName; public string status; }
    
    public class retDesks { [DataMember] public List<deskRet> destinations; }
    
    public class deskRet { public string destinationName; public string status; }
    
    ...
    
    List<deskRet> d1 = _desks.Select(e => 
        new deskRet{ destinationName=e.destinationName, status=e.status } 
        ).ToList<deskRet>(); // maybe I'm working to hard to guarantee the type.  But I'm okay with that
    return(new retDesks{ destinations=d1 };
