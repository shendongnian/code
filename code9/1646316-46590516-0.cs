    public override bool Equals(object obj)
    {
        return MyEquals(obj, new HashSet<Foo>(ReferenceEqualityComparer<Foo>.Inst));
    }
    public bool MyEquals(object obj, HashSet<Foo> checkedItems)
    {
        Foo other = obj as Foo;
        if (other == null)
            return false;
        if (checkedItems.Contains(this) && checkedItems.Contains(other))
            return true;
        checkedItems.Add(this);
        checkedItems.Add(other);
        return Name.Equals(other.Name) && Reference.MyEquals(other.Reference, checkedItems);
    }
