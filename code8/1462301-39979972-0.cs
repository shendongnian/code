    var results = context.Members;
    if(vm.Active.HasValue)
    {
        results = results.Where(x => x.Active == vm.Active.Value);
    }
    if(!string.IsNullOrEmpty vm.FirstName))
    {
        results = results.Where(x => x.FirstName == vm.FirstName);
    }
    //and so on until...
    return results.ToList();
