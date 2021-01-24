    class MyDataContractSurrogate : IDataContractSurrogate
    {
        public Type GetDataContractType(Type type)
        {
            if (type == typeof(KeepTruckinCompanyWebHook))
            {
                return typeof(Dictionary<string, Dictionary<string, object>>);
            }
            return type;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            if (obj.GetType() == typeof(Dictionary<string, Dictionary<string, object>>) &&
                targetType == typeof(KeepTruckinCompanyWebHook))
            {
                var webHook = new KeepTruckinCompanyWebHook();
                var outerDict = (Dictionary<string, Dictionary<string, object>>)obj;
                var innerDict = outerDict["company_webhook"];
                foreach (PropertyInfo prop in GetDataMemberProperties(typeof(KeepTruckinCompanyWebHook)))
                {
                    DataMemberAttribute att = prop.GetCustomAttribute<DataMemberAttribute>();
                    object value;
                    if (innerDict.TryGetValue(att.Name, out value))
                    {
                        prop.SetValue(webHook, value);
                    }
                }
                return webHook;
            }
            return obj;
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj.GetType() == typeof(KeepTruckinCompanyWebHook) &&
                targetType == typeof(Dictionary<string, Dictionary<string, object>>))
            {
                var webHook = (KeepTruckinCompanyWebHook)obj;
                var outerDict = new Dictionary<string, Dictionary<string, object>>();
                var innerDict = new Dictionary<string, object>();
                outerDict.Add("company_webhook", innerDict);
                foreach (PropertyInfo prop in GetDataMemberProperties(typeof(KeepTruckinCompanyWebHook)))
                {
                    DataMemberAttribute att = prop.GetCustomAttribute<DataMemberAttribute>();
                    innerDict.Add(att.Name, prop.GetValue(webHook));
                }
                return outerDict;
            }
            return obj;
        }
        private IEnumerable<PropertyInfo> GetDataMemberProperties(Type type)
        {
            return type.GetProperties().Where(p => p.CanRead && p.CanWrite && p.GetCustomAttribute<DataMemberAttribute>() != null);
        }
        // ------- The rest of these methods do not need to be implemented -------
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public void GetKnownCustomDataTypes(System.Collections.ObjectModel.Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            throw new NotImplementedException();
        }
        public System.CodeDom.CodeTypeDeclaration ProcessImportedType(System.CodeDom.CodeTypeDeclaration typeDeclaration, System.CodeDom.CodeCompileUnit compileUnit)
        {
            throw new NotImplementedException();
        }
    }
