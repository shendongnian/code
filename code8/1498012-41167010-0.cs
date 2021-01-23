    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }
    public override bool Equals(object obj)
    {
        return obj.ToString() == this.ToString();
    }
