    public VoyageReservedViewModel
    {
       public IEnumerable<string> preFactorID { get; set; }
       public int Code{ get; set; } 
    }
    VoyageReservedViewModel Obj = new VoyageReservedViewModel();
    var list = new List<string>();
    foreach (var item in result)
    {    
        list.Add("My String Value");
    }
    obj.preFactorID = list; // List<T> is an IEnumerable<T>
