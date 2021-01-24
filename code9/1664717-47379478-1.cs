    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Permissions;
    [assembly: AssemblyVersion("0.0.0.0")]
    [assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
    [assembly: CompilationRelaxations(8)]
    [assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
    [assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
    [module: UnverifiableCode]
    public class MyClass
    {
        [CompilerGenerated]
        private sealed class <>c__DisplayClass0_0
        {
            public int threshold;
            internal bool <MyMethod>b__0(int value)
            {
                return value >= this.threshold;
            }
        }
        public void MyMethod()
        {
            MyClass.<>c__DisplayClass0_0 <>c__DisplayClass0_ = new MyClass.<>c__DisplayClass0_0();
            int[] expr_0D = new int[5];
            RuntimeHelpers.InitializeArray(expr_0D, fieldof(<PrivateImplementationDetails>.D603F5B3D40E40D770E3887027E5A6617058C433).FieldHandle);
            int[] source = expr_0D;
            <>c__DisplayClass0_.threshold = 6;
            IEnumerable<int> source2 = source.Where(new Func<int, bool>(<>c__DisplayClass0_.<MyMethod>b__0));
            <>c__DisplayClass0_.threshold = 3;
            List<int> list = source2.ToList<int>();
        }
    }
    [CompilerGenerated]
    internal sealed class <PrivateImplementationDetails>
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 20)]
        private struct __StaticArrayInitTypeSize=20
        {
        }
        internal static readonly <PrivateImplementationDetails>.__StaticArrayInitTypeSize=20 D603F5B3D40E40D770E3887027E5A6617058C433 = bytearray(1, 0, 0, 0, 3, 0, 0, 0, 5, 0, 0, 0, 7, 0, 0, 0, 9, 0, 0, 0);
    }
