    public override bool Equals(object obj)
    {
        // If parameter cannot be cast to Demo or is null return false.
        Demo p = obj as Demo;
        if (p == null)
        {
            return false;
        }
    
        // Return true if the fields match:
        return (MyPropertyx == p.MyProperty));
    }
