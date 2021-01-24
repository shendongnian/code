    public override bool Equals(object obj)
    {
        var other = (Room) obj;
        return string.Equals(Name, other.Name) 
            && Adults == other.Adults 
            && Children == other.Children;
    }
    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Name.GetHashCode();
            hashCode = (hashCode * 397) ^ Adults;
            hashCode = (hashCode * 397) ^ Children;
            return hashCode;
        }
    }
