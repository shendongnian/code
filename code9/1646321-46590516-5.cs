    public override bool Equals(object obj)
    {
        return MyEquals(obj, new HashSet<(Foo,Foo)>(ValuePairRefEqualityComparer<Foo>.Instance));
    }
    private bool MyEquals(object obj, HashSet<(Foo,Foo)> checkedPairs)
    {
        Foo other = obj as Foo;
        if (other == null)
            return false;
        if (!Name.Equals(other.Name))
            return false;
        if (checkedPairs.Contains((this,other)) || checkedPairs.Contains((other,this)))
            return true;
        checkedPairs.Add((this,other));
        return Reference.MyEquals(other.Reference, checkedItems);
    }
