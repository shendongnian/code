    internal class SerializerSurrogate : IDataContractSurrogate
    {
        /// <summary>
        /// Identifies a type transformation.
        /// </summary>
        /// <param name="type">The type being inspected.</param>
        /// <returns>The type to transform to. If the same type is used, transform does not happen.</returns>
        public Type GetDataContractType(Type type)
        {
            if (type == typeof(sourceType))
                return typeof(targetType);
            return type;
        }
        /// <summary>
        /// During serialization, transfrom from sourceType to targetType.
        /// </summary>
        /// <param name="obj">The object instance.</param>
        /// <param name="targetType">The source type.</param>
        /// <returns>A new object instance based on targetType.</returns>
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj is sourceType)
            {
                // Create instance of targetType from the obj variable which is sourceType
                // Set the properties of the targetType, based on the (sourceType)obj variable.
                return new targetType();
            }
            
            return obj;
        }
        /// <summary>
        /// During deserialization, transform from targetType to sourceType.
        /// </summary>
        /// <param name="obj">The object instance.</param>
        /// <param name="targetType">The target type.</param>
        /// <returns>A new object instance based on sourceType.</returns>
        public object GetDeserializedObject(object obj, Type targetType)
        {
            if (obj is targetType)
            {
                // Create instance of sourceType from the obj variable which is targetType
                // Set the properties of the sourceType, based on the (targetType)obj variable.
                return new sourceType();
            }
            return obj;
        }
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            return null;
        }
        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            return null;
        }
    }
