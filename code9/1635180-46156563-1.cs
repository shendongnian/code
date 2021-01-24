    static void Main(string[] args)
    {
    
        var parentModel = new ContainerCloudStorageAccount { StorageAccount = new CloudStorageAccount() } ;
        var type = CreateType("MyOverride", () => parentModel.StorageAccount);
        var value = (BasicModel)type.GetConstructors().First().Invoke(new object[0]);
        Console.WriteLine(value.StorageAccount);
    }
    
    public static Type CreateType(string name, Func<CloudStorageAccount> getter)
    { 
        AppDomain myDomain = Thread.GetDomain();
        AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(new AssemblyName("dynamicTypes"), AssemblyBuilderAccess.Run);
        ModuleBuilder interfaceImplementationModule = myAsmBuilder.DefineDynamicModule("overrrides");
    
        TypeBuilder typeBuilder = interfaceImplementationModule.DefineType(name,
            TypeAttributes.Public | TypeAttributes.Class,
            typeof(BasicModel));
    
        var newMethod2 = typeBuilder.DefineMethod("get_StorageAccount", MethodAttributes.Virtual | MethodAttributes.Public,
                typeof(CloudStorageAccount), Type.EmptyTypes
        );
        typeBuilder.DefineMethodOverride(newMethod2, typeof(BasicModel).GetProperty("StorageAccount").GetGetMethod());
    
        var fieldInfo = typeBuilder.DefineField("getter", typeof(Func<CloudStorageAccount>), FieldAttributes.Static | FieldAttributes.Public);
    
        var IlGen2 = newMethod2.GetILGenerator();
        IlGen2.Emit(OpCodes.Ldsfld, fieldInfo);
        IlGen2.Emit(OpCodes.Call, typeof(Func<CloudStorageAccount>).GetMethod("Invoke"));
        IlGen2.Emit(OpCodes.Ret);
    
        typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
        var type = typeBuilder.CreateType();
        type.GetField("getter").SetValue(null, getter);
    
        return type;
    }
