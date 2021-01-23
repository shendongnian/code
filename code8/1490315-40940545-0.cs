    var idsTrue = list.Where(x => x.IsActive).Select(x => x.Id).ToList();
    var idsFalse = list.Where(x => !x.IsActive).Select(x => x.Id).ToList();
    
    ctx.dllSet.Where(x => idsTrue.Contains(x.Id)).Update(x => new Dll() {IsActive = true});
    ctx.dllSet.Where(x => idsFalse.Contains(x.Id)).Update(x => new Dll() {IsActive = false});
