    var listTrue = ctx.Users.Where(...).Select(s=> new CustomClass{...}).ToList();
    var listFalse = ctx.Users.Where(...).Select(s=> new CustomClass{...}).ToList();
    var result = new List<CustomClass>();
    result.AddRange(listTrue);
    result.AddRange(listFalse);
    return result;
