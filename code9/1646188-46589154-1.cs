    static HashSet<Club> checkedItems = new HashSet<Club>(ReferenceEqualityComparer<Club>.Inst);
    public override bool Equals(object obj)
    {
        Club other = obj as Club;
        if (other == null)
            return false;
         if (checkedItems.Contains(this) && checkedItems.Contains(other))
            return true;
        checkedItems.Add(this);
        checkedItems.Add(other);
        bool equal = Name.Equals(other.Name) && Members.SetEquals(other.Members);
        checkedItems.Clear();
		return equal;
    }
