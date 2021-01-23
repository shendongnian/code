    .method public hidebysig static 
        void AddHandler (
                class [mscorlib]System.EventHandler`1<class DLLNAMESPACE.Debugger/DebugMessageArgs> eventHandler
        ) cil managed 
    {
        // Method begins at RVA 0x211c
        // Code size 29 (0x1d)
        .maxstack 8
        IL_0000: nop
        IL_0001: call class DLLNAMESPACE.Debugger DLLNAMESPACE.Debugger::get_Instance()
        IL_0006: dup
        IL_0007: ldfld class [mscorlib]System.EventHandler`1<class DLLNAMESPACE.Debugger/DebugMessageArgs> DLLNAMESPACE.Debugger::DebugMessageEvent
        IL_000c: ldarg.0
        IL_000d: call class [mscorlib]System.Delegate [mscorlib]System.Delegate::Combine(class [mscorlib]System.Delegate, class [mscorlib]System.Delegate)
        IL_0012: castclass class [mscorlib]System.EventHandler`1<class DLLNAMESPACE.Debugger/DebugMessageArgs>
        IL_0017: stfld class [mscorlib]System.EventHandler`1<class DLLNAMESPACE.Debugger/DebugMessageArgs> DLLNAMESPACE.Debugger::DebugMessageEvent
        IL_001c: ret
    } // end of method DebuggerHelper::AddHandler
