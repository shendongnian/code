    var valMethods = new List<Func<ValidationResult>>
    {
        ()=>Method1(number,family),
        ()=>Method2(name),
        // ...
    };
    foeach(var valMethod in valMethods)
    {
        var valResult = valMethod();
        if (!valResult.IsValid)
        {
            return valResult.Errors.First();
        }
    }
