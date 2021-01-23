    public override bool Equals(object obj)
    {
        // If parameter is null return false.
        if (obj == null)
        {
            return false;
        }
    
        // If parameter cannot be cast to Point return false.
        Demo p = obj as Demo;
        if (p == null)
        {
            return false;
        }
    
        // Return true if the fields match:
        return (MyPropertyx == p.MyProperty));
    }
