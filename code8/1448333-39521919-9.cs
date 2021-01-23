            if (encodedType == CustomAttributeEncoding.Array)
            {
                parameterType = (RuntimeType)parameterType.GetElementType();
                encodedArrayType = CustomAttributeData.TypeToCustomAttributeEncoding(parameterType);
            }
 
            if (encodedType == CustomAttributeEncoding.Enum || encodedArrayType == CustomAttributeEncoding.Enum)
            {
                encodedEnumType = TypeToCustomAttributeEncoding((RuntimeType)Enum.GetUnderlyingType(parameterType));
                enumName = parameterType.AssemblyQualifiedName;
            }
