    // override the object comparison function: Equals
    public override bool Equals(object obj)
    {
        if(obj == null)
        {
            return false;
        }
        if(obj is Teacher)
        {
            return this.Salary == ((Teacher)obj).Salary;
        }
        return base.Compare(obj); // most likely to be false...
    }
    // Overriding GetHashCode is necessary to override the Equals function
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    // override the < <= > >= == != operators
    public static bool operator <(Teacher t1, Teacher t2) 
    {
        return t1.Salary < t2.Salary;
    }
    public static bool operator >(Teacher t1, Teacher t2) 
    {
        return t1.Salary > t2.Salary;
    }
    public static bool operator <=(Teacher t1, Teacher t2) 
    {
        return t1.Salary <= t2.Salary;
    }
    public static bool operator >=(Teacher t1, Teacher t2) 
    {
        return t1.Salary < t2.Salary;
    }
    public static bool operator ==(Teacher t1, Teacher t2) 
    {
        return t1.Salary == t2.Salary;
    }
    public static bool operator !=(Teacher t1, Teacher t2) 
    {
        return t1.Salary != t2.Salary;
    }
