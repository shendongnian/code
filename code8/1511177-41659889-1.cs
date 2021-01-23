    IL_0000: newobj instance void ConsoleApp5.Program/'<>c__DisplayClass4_0'::.ctor()
	IL_0005: stloc.0
	IL_0006: ldloc.0
	IL_0007: ldarg.0
	IL_0008: stfld string ConsoleApp5.Program/'<>c__DisplayClass4_0'::id
	IL_000d: ldsfld class [mscorlib]System.Collections.Concurrent.ConcurrentDictionary`2<string, class ConsoleApp5.TestObject> ConsoleApp5.Program::testDictionary
	IL_0012: ldloc.0
	IL_0013: ldftn instance bool ConsoleApp5.Program/'<>c__DisplayClass4_0'::'<checkid2>b__0'(valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string, class ConsoleApp5.TestObject>)
	IL_0019: newobj instance void class [mscorlib]System.Func`2<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string, class ConsoleApp5.TestObject>, bool>::.ctor(object, native int)
	IL_001e: call bool [System.Core]System.Linq.Enumerable::Any<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string, class ConsoleApp5.TestObject>>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>, class [mscorlib]System.Func`2<!!0, bool>)
	IL_0023: brtrue.s IL_0027
	IL_0025: ldc.i4.0
	IL_0026: ret
	IL_0027: ldc.i4.1
	IL_0028: ret
