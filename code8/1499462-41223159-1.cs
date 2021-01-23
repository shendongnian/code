    private static bool HasEqualityOperator(ITypeSymbol type)
    {
        switch (type.SpecialType)
        {
            case SpecialType.System_Enum:
            case SpecialType.System_Boolean:
            case SpecialType.System_Char:
            case SpecialType.System_SByte:
            case SpecialType.System_Byte:
            case SpecialType.System_Int16:
            case SpecialType.System_UInt16:
            case SpecialType.System_Int32:
            case SpecialType.System_UInt32:
            case SpecialType.System_Int64:
            case SpecialType.System_UInt64:
            case SpecialType.System_Decimal:
            case SpecialType.System_Single:
            case SpecialType.System_Double:
            case SpecialType.System_String:
            case SpecialType.System_IntPtr:
            case SpecialType.System_UIntPtr:
            case SpecialType.System_DateTime:
                return true;
        }
        if (type.TypeKind == TypeKind.Enum)
        {
            return true;
        }
        foreach (var op in type.GetMembers("op_Equality"))
        {
            var opMethod = op as IMethodSymbol;
            if (opMethod?.Parameters.Length == 2 &&
                type.Equals(opMethod.Parameters[0].Type) &&
                type.Equals(opMethod.Parameters[1].Type))
            {
                return true;
            }
        }
        return false;
    }
