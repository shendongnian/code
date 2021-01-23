            const string typeName = "ObservableTestCollection";
            const string fieldName = "Parent";
            const string assemblyName = "TestAssembly";
            const string assemblyFileName = assemblyName + ".dll";
            var domain = AppDomain.CurrentDomain;
            var assemblyBuilder = domain.DefineDynamicAssembly(new AssemblyName(assemblyName), AssemblyBuilderAccess.RunAndSave);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName, assemblyFileName);
            var baseType = typeof(ObservableCollection<>);
            var typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Class | TypeAttributes.Public, baseType);
            var genericParameters = typeBuilder.DefineGenericParameters("T");
            var genericParameter = genericParameters.First();
            
            var fieldBuilder = typeBuilder.DefineField(fieldName, genericParameter, FieldAttributes.Public);
            //First constructor ObservableTestColleciton(T parent)
            var ctorParameters = new Type[] { genericParameter };
            var baseCtor = baseType.GetConstructor(Type.EmptyTypes);
            var ctorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis, ctorParameters);
            var generator = ctorBuilder.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0); // load this
            generator.Emit(OpCodes.Call, baseCtor); //call base constructor
            generator.Emit(OpCodes.Ldarg_0); // load this
            generator.Emit(OpCodes.Ldarg_1); // load argument value
            generator.Emit(OpCodes.Stfld, fieldBuilder); // store into Parent field
            generator.Emit(OpCodes.Ret); //return
            //Second constructor ObservableTestColleciton(T parent, IEnumerable<T> source):base(source)
            var baseCtorParam = typeof(IEnumerable<>).MakeGenericType(genericParameter);
            ctorParameters = new [] { genericParameter, baseCtorParam };
            baseCtor = baseType.GetConstructors()
                               .First(c => c.GetParameters().FirstOrDefault()?.ParameterType?.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            ctorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis, ctorParameters);
            generator = ctorBuilder.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0); // load this
            generator.Emit(OpCodes.Ldarg_2); // load second argument value
            generator.Emit(OpCodes.Call, baseCtor); //call base constructor
            generator.Emit(OpCodes.Ldarg_0); // load this
            generator.Emit(OpCodes.Ldarg_1); // load first argument value
            generator.Emit(OpCodes.Stfld, fieldBuilder); // store into Parent field
            generator.Emit(OpCodes.Ret); //return
            var genericType = typeBuilder.CreateType();
            var type = genericType.MakeGenericType(typeof(string));
            var fieldInfo = type.GetField(fieldName);
            var obj1 = Activator.CreateInstance(type, "Parent1");
            Console.WriteLine("Ctor1 field value :" + fieldInfo.GetValue(obj1)); //check that field value was set
            var obj2 = Activator.CreateInstance(type, "Parent2", new List<string>());
            Console.WriteLine("Ctor1 field value :" + fieldInfo.GetValue(obj2));
            assemblyBuilder.Save(assemblyFileName);
