    public override bool Equals(object obj)
    {
        return ID == (obj as Student).ID;
    }
    public override int GetHashCode()
    {
        return ID;
    }
