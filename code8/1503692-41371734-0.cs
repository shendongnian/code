            const string assemblyName = "SampleAssembly";
            const string fieldName = "Items";
            const string typeName = "Sample";
            const string assemblyFileName = assemblyName + ".dll";
            var domain = AppDomain.CurrentDomain;
            var assemblyBuilder = domain.DefineDynamicAssembly(new AssemblyName(assemblyName), AssemblyBuilderAccess.RunAndSave);
            
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName, assemblyFileName);
            var typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Class | TypeAttributes.Public);
            var typeOfCts = typeof(ObservableTestCollection<>);
            var genericTypeOfCts = typeOfCts.MakeGenericType(typeBuilder);
            var fieldBuilder = typeBuilder.DefineField(fieldName, genericTypeOfCts, FieldAttributes.Public);
            //first constructor Sample()
            var ctorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis, Type.EmptyTypes);
            var obsCtor1 = typeOfCts.GetConstructors().First(c => c.GetParameters().Length == 1);
            obsCtor1 = TypeBuilder.GetConstructor(genericTypeOfCts, obsCtor1); //hack to get close generic type ctor with typeBuilder as generic parameter
            var generator = ctorBuilder.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0); //load this for base type constructor
            generator.Emit(OpCodes.Call, typeof(object).GetConstructors().Single());
            generator.Emit(OpCodes.Ldarg_0); //load this for field setter
            generator.Emit(OpCodes.Ldarg_0); //load this for ObservableTestCollection constructor
            generator.Emit(OpCodes.Newobj, obsCtor1); //call ObservableTestCollection constructor, it will put point to new object in stack
            generator.Emit(OpCodes.Stfld, fieldBuilder); // store into Items
            generator.Emit(OpCodes.Ret); //return
            //second constructor Sample(IEnumerable<Sample> source)
            var ctorParam = typeof(IEnumerable<>).MakeGenericType(typeBuilder);
            ctorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis, new Type[] { ctorParam } );
            obsCtor1 = typeOfCts.GetConstructors().First(c => c.GetParameters().Length == 2);
            obsCtor1 = TypeBuilder.GetConstructor(genericTypeOfCts, obsCtor1); //hack to get close generic type ctor with typeBuilder as generic parameter
            generator = ctorBuilder.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0); //load this for base type constructor
            generator.Emit(OpCodes.Call, typeof(object).GetConstructors().Single());
            generator.Emit(OpCodes.Ldarg_0); //load this for field setter
            generator.Emit(OpCodes.Ldarg_0); //load this for ObservableTestCollection constructor
            generator.Emit(OpCodes.Ldarg_1); //load IEnumerable for ObservableTestCollection constructor
            generator.Emit(OpCodes.Newobj, obsCtor1); //call ObservableTestCollection constructor, it will put point to new object in stack
            generator.Emit(OpCodes.Stfld, fieldBuilder); // store into Items
            generator.Emit(OpCodes.Ret); //return
            var type = typeBuilder.CreateType();
            var obj1 = Activator.CreateInstance(type);
            var parameter = Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            var obj2 = Activator.CreateInstance(type, parameter);
            assemblyBuilder.Save(assemblyFileName);
