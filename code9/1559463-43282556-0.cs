    using System;
    
    static class P
    {
        static void Main()
        {
            // resolve the (object, IntPtr) ctor
            var ctor = typeof(Func<string, string>).GetConstructors()[0];
            // resolve the target method
            var mHandle = typeof(P).GetMethod(nameof(Concat))
                .MethodHandle.GetFunctionPointer();
            object target = null; // because: static
            // create delegate instance
            var del = (Func<string, string>)ctor.Invoke(new object[] { target, mHandle });
            var result = del("abc");
            Console.WriteLine(result); // "-abc"
        }
        public static string Concat(string s1, string s2)
        {
            return string.Format("{0}-{1}", s1, s2);
        }
    }
