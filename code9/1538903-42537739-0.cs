    SortedSet<string> alreadyTried = new SortedSet<string>();
    
    if(!HasSetBeenTried("1:1:1"){   
        // do whatever  
    }
    if(!HasSetBeenTried("500:212:100"){   
        // do whatever  
    }
    public bool HasSetBeenTried(string set){
        if(alreadyTried.Contains(set)) return false;
        alreadyTried.Add(set);
        return true;
    }
    
