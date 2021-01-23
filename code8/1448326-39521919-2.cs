            if (encodedType == CustomAttributeEncoding.Enum || encodedArrayType == CustomAttributeEncoding.Enum)
            {
                encodedEnumType = TypeToCustomAttributeEncoding((RuntimeType)Enum.GetUnderlyingType(parameterType));
                enumName = parameterType.AssemblyQualifiedName;
            }
