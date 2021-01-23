    public override EnumWorkflowJobType MyType()
    {
        string stringifiedType = this.GetType().ToString();
    
        var myEnumType = (EnumWorkflowJobType)Enum.Parse(typeof(EnumWorkflowJobType), stringifiedType);
        return myEnumType;
    }
