    var bDic = listB.ToDictionary(a => a.Id, a => a); // for faster searching
    var listC = listA.Select(a => new C()
    {
       id = a.id,
       name = a.name,
       status = a.status,
       gender = BDic[a.id].gender,
       level = BDic[a.Id].level,
    }
    .ToList();
