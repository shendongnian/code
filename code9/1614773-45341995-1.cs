    private static void BuildAssembly()
    {
        AssemblyName assemblyName;
        AssemblyBuilder assmBuilder;
        ModuleBuilder modBuilder;
        assemblyName = new AssemblyName( "Generated" );
        // Note the save directory is the directory containing this project's solution file.
        assmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
            assemblyName,
            AssemblyBuilderAccess.RunAndSave,
            Assembly.GetExecutingAssembly().Location + @"\..\..\..\.."
        );
        modBuilder = assmBuilder.DefineDynamicModule(
            assemblyName.Name,
            assemblyName.Name + ".dll",
            true
        );
        /*
         * public class GenericsDemo {
         * }
         */
        TypeBuilder typeBuilder = modBuilder.DefineType(
            "Generated.GenericsDemo",
                TypeAttributes.Public
        );
        BuildCallListMethod( typeBuilder );
        typeBuilder.CreateType();
        assmBuilder.Save( assemblyName.Name + ".dll" );
    }
    private static void BuildCallListMethod( TypeBuilder typeBuilder )
    {
        // public void CallList() {
        //     List<object> list = new List<object>();
        //     object thing = new object();
        //     list.Add(thing);
        // }
        var listOfObject = typeof( List<object> );
        var objType = typeof( object );
        // public void CallList() { 
        var method = typeBuilder.DefineMethod( 
            "CallList", 
            MethodAttributes.Public | MethodAttributes.HideBySig, 
            CallingConventions.HasThis 
        );
        var gen = method.GetILGenerator();
        // List<int> list;
        var listLocal = gen.DeclareLocal( listOfObject );
        listLocal.SetLocalSymInfo( "list" );
        // object thing;
        var thingLocal = gen.DeclareLocal( objType );
        thingLocal.SetLocalSymInfo( "thing" );
        // list = new List<object>();
        gen.Emit( OpCodes.Newobj, listOfObject.GetConstructor( Type.EmptyTypes ) );
        gen.Emit( OpCodes.Stloc_0 );
        // thing = new object();
        gen.Emit( OpCodes.Newobj, objType.GetConstructor( Type.EmptyTypes ) );
        gen.Emit( OpCodes.Stloc_1 );
        // list.Add( thing );
        gen.Emit( OpCodes.Ldloc_0 ); // loads `list`.
        gen.Emit( OpCodes.Ldloc_1 ); // loads `thing`.
        gen.EmitCall( OpCodes.Callvirt, listOfObject.GetMethod( "Add" ), null );
        gen.Emit( OpCodes.Ret );
    }
