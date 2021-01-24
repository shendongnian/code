    public static implicit operator TypeAIntermediate(TypeA a)
    {
        return Convert(a, new Dictionary<TypeA, TypeAIntermediate>());
    }
    private static TypeAIntermediate Convert(
        Type A a, 
        Dictionary<TypeA, TypeAIntermediate> lookup)
    {
        TypeAIntermediate aI;
        if(lookup.TryGetValue(a, out aI))
        {
            return aI;
        }
        
        aI = new TypeAintermediate();
        lookup.Add(a, aI);
        List<TypeAIntermediate> children = new List<TypeAIntermediate>();
        foreach (TypeA item in a.SomeAs)
            children.Add(Convert(item, lookup)); 
        aI.TypeAStuff = a.TypeAStuff;
        aI.JustOneB = a.JustOneB;
        aI.SomeAs = children;
        return aI;
    }
