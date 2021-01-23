            AppDomain ad = AppDomain.CurrentDomain;
            AssemblyBuilder ab = ad.DefineDynamicAssembly(new AssemblyName("toto.dll"), AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder mb = ab.DefineDynamicModule("toto.dll");
            TypeBuilder tb = mb.DefineType("toto.Sample", TypeAttributes.Public | TypeAttributes.Class);
            FieldBuilder fb = tb.DefineField("<Children>k__BackingField", typeof(ObservableCollection<>).MakeGenericType(tb), FieldAttributes.Private | FieldAttributes.InitOnly);
            fb.SetCustomAttribute(new CustomAttributeBuilder(typeof(CompilerGeneratedAttribute).GetConstructor(new Type[0]), new object[0]));
            PropertyBuilder pb = tb.DefineProperty("Children", PropertyAttributes.None, typeof(ObservableCollection<>).MakeGenericType(tb), new Type[0]);
            MethodBuilder getter = tb.DefineMethod("get_Children", MethodAttributes.Public, CallingConventions.HasThis, typeof(ObservableCollection<>).MakeGenericType(tb), new Type[0]);
            getter.SetCustomAttribute(new CustomAttributeBuilder(typeof(CompilerGeneratedAttribute).GetConstructor(new Type[0]), new object[0]));
            ILGenerator ilgen = getter.GetILGenerator();
            ilgen.Emit(OpCodes.Ldarg_0);
            ilgen.Emit(OpCodes.Ldfld, fb);
            ilgen.Emit(OpCodes.Ret);
            pb.SetGetMethod(getter);
            PropertyBuilder pbhas = tb.DefineProperty("HasChildren", PropertyAttributes.None, typeof(bool), new Type[0]);
            MethodBuilder hasgetter = tb.DefineMethod("get_HasChildren", MethodAttributes.Public, CallingConventions.HasThis, typeof(bool), new Type[0]);
            ilgen = hasgetter.GetILGenerator();
            Label notNullLabel = ilgen.DefineLabel();
            ilgen.Emit(OpCodes.Ldarg_0);
            ilgen.Emit(OpCodes.Call, getter);
            ilgen.Emit(OpCodes.Dup);
            ilgen.Emit(OpCodes.Brtrue, notNullLabel);
            ilgen.Emit(OpCodes.Pop);
            ilgen.Emit(OpCodes.Ldc_I4_0);
            ilgen.Emit(OpCodes.Ret);
            ilgen.MarkLabel(notNullLabel);
            
            MethodInfo mi = typeof(Enumerable).GetMethods()
                                     .Where(m => m.Name == "Count" && m.GetGenericArguments().Length == 1 && m.GetParameters().Length == 1)
                                     .First()
                                     .MakeGenericMethod(tb);
            ilgen.Emit(OpCodes.Call, mi);
            ilgen.Emit(OpCodes.Ldc_I4_0);
            ilgen.Emit(OpCodes.Cgt);
            
            ilgen.Emit(OpCodes.Ret);
            pbhas.SetGetMethod(hasgetter);
            tb.CreateType();
            ab.Save("toto.dll");
