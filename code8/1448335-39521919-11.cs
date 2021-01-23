        else if (encodedType == CustomAttributeEncoding.Array)
        {                
            encodedType = encodedArg.CustomAttributeType.EncodedArrayType;
            Type elementType;
            
            if (encodedType == CustomAttributeEncoding.Enum)
            {
                elementType = ResolveType(scope, encodedArg.CustomAttributeType.EnumName);
            }
