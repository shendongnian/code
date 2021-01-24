    using System;
    using System.Reflection.Emit;
    
    static class Program
    {
        static void Main()
        {
    
            var method = new DynamicMethod("create", typeof(Foo), null);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(Foo));
            // initialize the local (essentially: the default ctor)
            il.Emit(OpCodes.Ldloca_S, local);
            il.Emit(OpCodes.Initobj, typeof(Foo));
            // load, box, and call CWL
            il.Emit(OpCodes.Ldloc_S, local);
            il.Emit(OpCodes.Box, typeof(Foo));
            il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine",
                new[] { typeof(object) }));
            // return the value of the 
            il.Emit(OpCodes.Ldloc_S, local);
            il.Emit(OpCodes.Ret);
    
            // call the emitted method
            var del = (Func<Foo>)method.CreateDelegate(typeof(Func<Foo>));
            var foo = del();        
        }
    
    }
    public struct Foo
    {
        int Id { get; }
        public override string ToString() => Id.ToString();
    }
