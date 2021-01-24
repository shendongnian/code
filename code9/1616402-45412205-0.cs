    public static int SizeOf(Object structure)
    {
        if (structure == null)
            throw new ArgumentNullException(nameof(structure));
        // we never had a check for generics here
        Contract.EndContractBlock();
        return SizeOfHelper(structure.GetType(), true);
    }
    public static int SizeOf(Type t)
    {
        if (t == null)
            throw new ArgumentNullException(nameof(t));
        if (!(t is RuntimeType))
            throw new ArgumentException(SR.Argument_MustBeRuntimeType, nameof(t));
        if (t.IsGenericType)
            throw new ArgumentException(SR.Argument_NeedNonGenericType, nameof(t));
        Contract.EndContractBlock();
        return SizeOfHelper(t, true);
    }
