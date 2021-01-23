      public class ObjectConverter
    {
        public static object Convert(string json, JSchema schema)
        {
            var type = CreateType(schema);
            var destObject = Newtonsoft.Json.JsonConvert.DeserializeObject(json, type);
            return destObject;
        }
        private static Type CreateType(JSchema schema)
        {
            Type result = null;
            var typeBuilder = GetTypeBuilder(Guid.NewGuid().ToString());
            foreach (var item in schema.Properties)
            {
                if (item.Value.Type == (Newtonsoft.Json.Schema.JSchemaType.Object | Newtonsoft.Json.Schema.JSchemaType.Null))
                {
                    Type type = CreateType(item.Value);
                    if (item.Value.Type != null)
                    {
                        CreateProperty(typeBuilder, item.Key, type);
                    }
                }
                else
                {
                    if (item.Value.Type != null)
                    {
                        CreateProperty(typeBuilder, item.Key, ConvertType(item.Value.Type.Value));
                    }
                }
            }
            result = typeBuilder.CreateType();
            return result;
        }
        private static Type ConvertType(JSchemaType source)
        {
            Type result = null;
            switch (source)
            {
                case JSchemaType.None:
                    break;
                case JSchemaType.String:
                    result = typeof(string);
                    break;
                case JSchemaType.Number:
                    result = typeof(float);
                    break;
                case JSchemaType.Integer:
                    result = typeof(int);
                    break;
                case JSchemaType.Boolean:
                    result = typeof(bool);
                    break;
                case JSchemaType.Object:
                    result = typeof(object);
                    break;
                case JSchemaType.Array:
                    result = typeof(Array);
                    break;
                case JSchemaType.Null:
                    result = typeof(Nullable);
                    break;
                case Newtonsoft.Json.Schema.JSchemaType.String | Newtonsoft.Json.Schema.JSchemaType.Null:
                    result = typeof(string);
                    break;
                default:
                    break;
            }
            return result;
        }
        private static TypeBuilder GetTypeBuilder(string typeSignature)
        {
            var an = new AssemblyName(typeSignature);
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            TypeBuilder tb = moduleBuilder.DefineType(typeSignature,
                    TypeAttributes.Public |
                    TypeAttributes.Class |
                    TypeAttributes.AutoClass |
                    TypeAttributes.AnsiClass |
                    TypeAttributes.BeforeFieldInit |
                    TypeAttributes.AutoLayout,
                    null);
            return tb;
        }
        private static void CreateProperty(TypeBuilder tb, string propertyName, Type propertyType)
        {
            FieldBuilder fieldBuilder = tb.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);
            PropertyBuilder propertyBuilder = tb.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);
            MethodBuilder getPropMthdBldr = tb.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
            ILGenerator getIl = getPropMthdBldr.GetILGenerator();
            getIl.Emit(OpCodes.Ldarg_0);
            getIl.Emit(OpCodes.Ldfld, fieldBuilder);
            getIl.Emit(OpCodes.Ret);
            MethodBuilder setPropMthdBldr =
                tb.DefineMethod("set_" + propertyName,
                  MethodAttributes.Public |
                  MethodAttributes.SpecialName |
                  MethodAttributes.HideBySig,
                  null, new[] { propertyType });
            ILGenerator setIl = setPropMthdBldr.GetILGenerator();
            Label modifyProperty = setIl.DefineLabel();
            Label exitSet = setIl.DefineLabel();
            setIl.MarkLabel(modifyProperty);
            setIl.Emit(OpCodes.Ldarg_0);
            setIl.Emit(OpCodes.Ldarg_1);
            setIl.Emit(OpCodes.Stfld, fieldBuilder);
            setIl.Emit(OpCodes.Nop);
            setIl.MarkLabel(exitSet);
            setIl.Emit(OpCodes.Ret);
            propertyBuilder.SetGetMethod(getPropMthdBldr);
            propertyBuilder.SetSetMethod(setPropMthdBldr);
        }
    }
