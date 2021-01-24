    static HashSet<(Club,Club)> checkedPairs
        = new HashSet<(Club,Club)>(ValuePairRefEqualityComparer<Club>.Instance);
    public override bool Equals(object obj)
    {
        Club other = obj as Club;
        if (other == null)
            return false;
         if (checkedPairs.Contains((this,other)) || checkedPairs.Contains((other,this)))
            return true;
        checkedPairs.Add((this,other));
        bool equal = Name.Equals(other.Name) && Members.SetEquals(other.Members);
        checkedPairs.Clear();
		return equal;
    }
