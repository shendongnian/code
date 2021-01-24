    IEnumerable TContextData;
    
    if (!string.IsNullOrEmpty(id)
    || !string.IsNullOrEmpty(name)
    || !string.IsNullOrEmpty(cell))
    {
        TContextData = (from e in db.mytable where (!string.IsNullOrEmpty(e.id)) select e); 
    }
    
    foreach(var i in TContextData.ToList())
    {    
        //do stuff
    }
