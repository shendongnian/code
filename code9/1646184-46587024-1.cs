    public override bool Equals(object obj)
    {
        if (Object.ReferenceEquals(this, obj))
            return true;
        Club other = obj as Club;
        if (other == null)
            return false;
        var personNameComparer = new PersonNameComparer();
        return Name.Equals(other.Name) 
            && Members.Count == other.Members.Count 
            && !Members.Except(other.Members, personNameComparer).Any();
    }
