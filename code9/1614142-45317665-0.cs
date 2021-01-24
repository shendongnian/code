    static void Main(string[] args)
    {
        var widget = new Widget();
        GetLengthMeasurer()(widget) = 7;
        Console.WriteLine(widget.Length);
    }
    private static WidgetMeasurer GetLengthMeasurer()
    {
        var fieldInfo = typeof(Widget).GetField("Length");
        var asmName = new AssemblyName("WidgetDynamicAssembly." + Guid.NewGuid().ToString());
        var asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndCollect);
        var moduleBuilder = asmBuilder.DefineDynamicModule("<Module>");
        var typeBuilder = moduleBuilder.DefineType("WidgetHelper");
        var methodBuilder = typeBuilder.DefineMethod("GetLength", MethodAttributes.Static | MethodAttributes.Public, typeof(int).MakeByRefType(), new[] { typeof(Widget) });
        var ilGen = methodBuilder.GetILGenerator();
        ilGen.Emit(OpCodes.Ldarg_0);
        ilGen.Emit(OpCodes.Ldflda, fieldInfo);
        ilGen.Emit(OpCodes.Ret);
        var type = typeBuilder.CreateType();
        var mi = type.GetMethod(methodBuilder.Name);
        var del = (WidgetMeasurer)mi.CreateDelegate(typeof(WidgetMeasurer));
        return del;
    }
