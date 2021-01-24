    var asmName = new AssemblyName("Win32");
    var asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Run);
    var modBuilder = asmBuilder.DefineDynamicModule("Win32", emitSymbolInfo: false);
    var typeBuilder = modBuilder.DefineType("Win32.User32", TypeAttributes.Class | TypeAttributes.Public);
    
    // Optional: Use if you need to set properties on DllImportAttribute
    var dllImportCtor = typeof(DllImportAttribute).GetConstructor(new Type[] { typeof(string) });
    var dllImportBuilder = new CustomAttributeBuilder(dllImportCtor, new object[] { "user32.dll" });
    
    var pinvokeBuilder = typeBuilder.DefinePInvokeMethod(
        name:              "ShowMessageBox",
        dllName:           "user32.dll",
        entryName:         "MessageBoxW",
        attributes:        MethodAttributes.Static | MethodAttributes.Public,
        callingConvention: CallingConventions.Standard,
        returnType:        typeof(int),  // typeof(void) if there is no return value.
        // TODO: Construct this array from user input somehow:
        parameterTypes:    new Type[] { typeof(IntPtr), typeof(string), typeof(string), typeof(uint) },
        nativeCallConv:    CallingConvention.Winapi,
        nativeCharSet:     CharSet.Unicode);
    
    pinvokeBuilder.SetCustomAttribute(dllImportBuilder);
    
    Type user32Type = typeBuilder.CreateType();
    
    const uint MB_YESNOCANCEL = 3;
    
    user32Type
        .GetMethod("ShowMessageBox", BindingFlags.Static | BindingFlags.Public)
        // TODO: User input goes here:
        .Invoke(null, new object[] { IntPtr.Zero, "Message Text", "Message Caption", MB_YESNOCANCEL });
