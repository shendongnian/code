    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Room) obj);
    }
    protected bool Equals(Room other)
    {
        return string.Equals(Name, other.Name) && Adults == other.Adults && Children == other.Children;
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
