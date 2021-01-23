    class MyDataContractSurrogate : IDataContractSurrogate
    {
        public Type GetDataContractType(Type type)
        {
            if (type == typeof(List<Thing>))
            {
                return typeof(Dictionary<string, Dictionary<string, object>>);
            }
            return type;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            if (obj.GetType() == typeof(Dictionary<string, Dictionary<string, object>>) &&
                targetType == typeof(List<Thing>))
            {
                List<Thing> list = new List<Thing>();
                foreach (var kvp in (Dictionary<string, Dictionary<string, object>>)obj)
                {
                    Thing thing = new Thing { ThingName = kvp.Key };
                    Dictionary<string, object> propsDict = kvp.Value;
                    foreach (PropertyInfo prop in GetDataMemberProperties(typeof(Thing)))
                    {
                        DataMemberAttribute att = prop.GetCustomAttribute<DataMemberAttribute>();
                        object value;
                        if (propsDict.TryGetValue(att.Name, out value))
                        {
                            prop.SetValue(thing, value);
                        }
                    }
                    list.Add(thing);
                }
                return list;
            }
            return obj;
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj.GetType() == typeof(List<Thing>) &&
                targetType == typeof(Dictionary<string, Dictionary<string, object>>))
            {
                var thingsDict = new Dictionary<string, Dictionary<string, object>>();
                foreach (Thing thing in (List<Thing>)obj)
                {
                    var propsDict = new Dictionary<string, object>();
                    foreach (PropertyInfo prop in GetDataMemberProperties(typeof(Thing)))
                    {
                        DataMemberAttribute att = prop.GetCustomAttribute<DataMemberAttribute>();
                        propsDict.Add(att.Name, prop.GetValue(thing));
                    }
                    thingsDict.Add(thing.ThingName, propsDict);
                }
                return thingsDict;
            }
            return obj;
        }
        private IEnumerable<PropertyInfo> GetDataMemberProperties(Type type)
        {
            return type.GetProperties().Where(p => p.CanRead && p.CanWrite && p.GetCustomAttribute<DataMemberAttribute>() != null);
        }
        // ------- The rest of these methods are not needed -------
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
