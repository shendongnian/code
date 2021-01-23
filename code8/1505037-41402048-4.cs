        if (!baseType.IsGenericDefinition)
            return baseType.IsAssignableFrom(typeToCheck);
        
        // assume typeToCheck is never a generic definition
        while (typeToCheck != null && typeToCheck != typeof(object))
        {
            if (typeToCheck.IsGenericType && baseType.IsAssignableFrom(typeToCheck.GetGenericDefinition()))
                return true;
            typeToCheck = typeToCheck.BaseType;
        }
        return false;
    }
