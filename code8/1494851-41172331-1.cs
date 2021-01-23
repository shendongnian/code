    SalesUnitDto result = null; 
    var list = _session.QueryOver<SalesUnit>()
        .SelectList(l => l
            .Select(x => x.Id).WithAlias(() => result.Id)
            .Select(x => x.Name).WithAlias(() => result.Name))
        .TransformUsingAliasToBean(typeof(SalesUnitDto))
        .Cacheable()
        .List<SalesUnitDto>();
