    [System.Security.SecuritySafeCritical]  // auto-generated
    public unsafe static Array CreateInstance(Type elementType, int length)
    {
        if ((object)elementType == null)
            throw new ArgumentNullException("elementType");
        if (length < 0)
            throw new ArgumentOutOfRangeException("length", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
        Contract.Ensures(Contract.Result<Array>() != null);
        Contract.Ensures(Contract.Result<Array>().Length == length);
        Contract.Ensures(Contract.Result<Array>().Rank == 1);
        Contract.EndContractBlock();
    
        RuntimeType t = elementType.UnderlyingSystemType as RuntimeType;
        if (t == null)
            throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "elementType");
        return InternalCreate((void*)t.TypeHandle.Value, 1, &length, null);
    }
