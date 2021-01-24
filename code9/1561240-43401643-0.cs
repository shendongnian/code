	object ContractToObject(SomeInterfaceType type, JsonObjectContract contract)
    {
        switch (type)
        {
            case SomeInterfaceType.Type1:
                {
                    return new Class1(Params);
                }
            case SomeInterfaceType.Type2:
                {
                    return new Class2(Params);
                }
				//...
            case SomeInterfaceType.None:
            default:
                {
                    return null;
                }
        }
    }
