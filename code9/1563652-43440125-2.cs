    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Security;
    using System.Security.Permissions;
    [assembly: AssemblyVersion("0.0.0.0")]
    [assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
    [assembly: CompilationRelaxations(8)]
    [assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
    [assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
    [module: UnverifiableCode]
    public class Program
    {
        public unsafe static void Main()
        {
            Person person = new Person();
            int* age = person.GetAge();
            *age = 50;
        }
    }
    public class Person
    {
        private int age;
        public unsafe int* GetAge()
        {
            return ref this.age;
        }
    }
