    var code = new CustomCode();
    code.isUsed = true;
    code.Code = GenerateNewCode();
    while(_db.CustomCode.Any(a => a.Code == code.Code)){
        code.Code = GenerateNewCode();
    }
    _db.CustomCode.add(code);
    _db.SaveChanges();
    return code.Code;
