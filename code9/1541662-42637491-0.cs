    using System;
    using System.Linq;
    using System.Threading;
    
    interface I
    {
        int Value { get; set; }
    }
    
    class C : I
    {
        public int Value { get; set; }
    }
    
    public class Test
    {
        static void Main()
        {
            var interfaceGetter = typeof(I).GetProperty("Value").GetMethod;
            var classGetter = typeof(C).GetProperty("Value").GetMethod;
            var interfaceMapping = typeof(C).GetInterfaceMap(typeof(I));
            
            var interfaceMethods = interfaceMapping.InterfaceMethods;
            var targetMethods = interfaceMapping.TargetMethods;
            for (int i = 0; i < interfaceMethods.Length; i++)
            {
                if (interfaceMethods[i] == interfaceGetter)
                {
                    var targetMethod = targetMethods[i];
                    Console.WriteLine($"Implementation is classGetter? {targetMethod == classGetter}");
                }
            }
        }
    }
