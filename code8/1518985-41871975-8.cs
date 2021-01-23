    if (contract.IsInstantiable)
    {
       if (type has default constructor or its a value type)
       {
           contract.DefaultCreator = get default (parameterless) constructor;
           contract.DefaultCreatorNonPublic = check if default constructor public
       }
       if (we have constructor marked with JsonConstructorAttribute)
       {
           contract.OverrideCreator = constructor marked with attribute
           contract.CreatorParameters = get properties which match constructor parameters
       }
       else if (contract.MemberSerialization == MemberSerialization.Fields)
       {
           // only if the upplication if fully trusted
           contract.DefaultCreator = FormatterServices.GetUninitializedObject 
       }
       else if (contract.DefaultCreator == null || contract.DefaultCreatorNonPublic)
       {
             if (we have one public constructor with parameters)
             {
                  contract.ParametrizedCreator = constructor with parameters;
                  contract.CreatorParameters = get properties which match ctor parameters
             }
       }
    }
