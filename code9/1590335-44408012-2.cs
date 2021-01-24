    using System;
    using System.Reflection.Emit;
    
    static class Program
    {
        static void Main()
        {
    
            var method = new DynamicMethod("create", typeof(Foo), new[] { typeof(int) });
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(Foo));
    
            // initialize the local (essentially: the default ctor)
            il.Emit(OpCodes.Ldloca_S, local);
            il.Emit(OpCodes.Initobj, typeof(Foo));
    
            // assign the parameter value to the property
            il.Emit(OpCodes.Ldloca_S, local);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call,
                typeof(Foo).GetProperty(nameof(Foo.Id)).GetSetMethod());
    
            // load, box, and call CWL
            il.Emit(OpCodes.Ldloc_S, local);
            il.Emit(OpCodes.Box, typeof(Foo));
            il.Emit(OpCodes.Call, typeof(Console).GetMethod(
                nameof(Console.WriteLine), new[] { typeof(object) }));
    
            // return the value of the 
            il.Emit(OpCodes.Ldloc_S, local);
            il.Emit(OpCodes.Ret);
    
            // call the emitted method
            var del = (Func<int, Foo>)method.CreateDelegate(typeof(Func<int, Foo>));
            var foo = del(42);
        }
    
    }
    public struct Foo
    {
        public int Id { get; set; } // not usually a good idea, note
        public override string ToString() => Id.ToString();
    }
