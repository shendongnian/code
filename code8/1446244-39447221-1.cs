    public override EnumClassNames MyType()
    {
        string stringifiedType = this.GetType().ToString();
    
        var myEnumType = (EnumClassNames)Enum.Parse(typeof(EnumClassNames), stringifiedType);
        return myEnumType;
    }
