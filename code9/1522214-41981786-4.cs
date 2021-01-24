    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        var node = (Node)obj;
        // instances are equal if and only if myInterface's are equal
        return myInterface == node.myInterface;
    }
