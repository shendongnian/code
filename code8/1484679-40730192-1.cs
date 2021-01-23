    public class FactorySurrogateSelector : IDataContractSurrogate
    {
        [DataContract]
        class FactorySurrogate
        {
        }
        readonly FactoryBase factory;
        public FactorySurrogateSelector(FactoryBase factory)
        {
            this.factory = factory;
        }
        #region IDataContractSurrogate Members
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public Type GetDataContractType(Type type)
        {
            if (typeof(FactoryBase).IsAssignableFrom(type))
                return typeof(FactorySurrogate);
            return type;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            if (obj is FactorySurrogate)
                return factory;
            return obj;
        }
        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj is FactoryBase)
            {
                return new FactorySurrogate();
            }
            return obj;
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            throw new NotImplementedException();
        }
        public System.CodeDom.CodeTypeDeclaration ProcessImportedType(System.CodeDom.CodeTypeDeclaration typeDeclaration, System.CodeDom.CodeCompileUnit compileUnit)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
