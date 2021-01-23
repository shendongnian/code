    if (contract.IsInstantiable)
    {
       if (type has default constructor or its a value type)
       {
           contract.DefaultCreator = GetDefaultConstructor();
           contract.DefaultCreatorNonPublic = check if default constructor public
       }
       if we have constructor marked with `JsonConstructorAttribute`
       {
           contract.OverrideCreator = GetThisConstructor()
           contract.CreatorParameters = get parameters which should be passed to constructor
       }
       else if (contract.DefaultCreator == null || contract.DefaultCreatorNonPublic)
       {
             if (we have one public constructor with parameters)
             {
                  contract.ParametrizedCrator = GetThatConstructor();
                  contract.CreatorParameters = get parameters
             }
       }
    }
