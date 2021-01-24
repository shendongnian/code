     var list3 = list2.Select(x => {
        int value = 0;
        // if the dict contains the key and the value is an integer
        if(dict.ContainsKey(x) && int.TryParse(dict[x], out value))
            return value;
        return x;
    })
    .Distinct()
    .Select(x => new MyClass(){ Value = x })
    .ToList();
