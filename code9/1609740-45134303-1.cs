    var bDic = listB.ToDictionary(a => a.id, a => a); // for faster searching
    var listC = listA.Select(a => new C()
    {
       id = a.id,
       name = a.name,
       status = a.status,
       gender = bDic[a.id].gender,
       level = bDic[a.id].level,
    }
    .ToList();
