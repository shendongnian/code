    public override bool Equals(Object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
    
        var otherPerson = (Person)obj;
    
        if (Name != otherPerson.Name)
        {
            return false;
        }
        if (Age != otherPerson.Age)
        {
            return false;
        }
        return true;
    }
