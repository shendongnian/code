    (from p in Pages join pa in PageAct on p.PageId equals pa.PageId
     select new
     {
         PageId = p.PageId,
         PgName = p.PgName,
         ActionId = pa.ActionId,
         ActionName = pa.ActionName,
         action = (int?)0
     }).Union(from p in Pages
     join pa in PageAct on p.PageId equals pa.PageId
     join rp in RolePerm on pa.ActionId equals rp.ActionId into jrs
     from jrResult in jrs.DefaultIfEmpty()
     where jrResult.RoleId == 1
     select new
     {
         PageId = p.PageId,
         PgName = p.PgName,
         ActionId = pa.ActionId,
         ActionName = pa.ActionName,
         action = (int?)jrResult.ActionId // should cast, even if ActionId is not nullable
                                          // because left join might give null
     })
