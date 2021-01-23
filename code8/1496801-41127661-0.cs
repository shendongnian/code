    public Family GetFamily(int? familyAge, int? age)
    {
        var families = GetAllFamilies();
    
        if(familyAge.HasValue)
            families = families.Where(x => x.familyAge = familyAge.value);
    
        if(age.HasValue)
            families = families.Where(x => x.age = age.value);
    
        return familes.ToList();
    }
