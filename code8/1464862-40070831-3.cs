    public class Program
    {
        /* This is the delegate class, it uses runtime code, not IL */
        public class DoSomething : System.MulticastDelegate
        {
            public DoSomething(object object, int method) { /*...*/ }
            public override void Invoke() { /*...*/ }
            public override void BeginInvoke() { /*...*/ }
            Public override void EndInvoke() { /*...*/ }
        }
        /* This is the hidden anonymous class,
           the system refers to it as '<>c__DisplayClass1_0'.
           notice it contains iCnt. */
        [CompilerGenerated()]
        private class '<>c__DisplayClass1_0'
        {
            /* iCnt was moved to here by the compiler. */
            public int iCnt;
            public '<>c__DisplayClass1_0'() { /* Default constructor */ }
            /* This is the method the delegate invokes.*/
            internal '<Main>b__0'()
            {
                Console.WriteLine(this.iCnt);
            }
        }
        public static void Main(string[] args)
        {
            '<>c__DisplayClass1_0' var0; // A reference to the anonymous class
            List<DoSomething> var1; // lstOfDelegate
            int var2; // temp variable for the increment
            bool var3; // temp variable for the while conditional
            List<DoSomething>.Enumerator var4; // enumerator, used by foreach
            DoSomething var5; // temp variable for the delegate
            
            // Instantiate the anonymous class
            // As you can see, there is only one instance,
            // so there is only one iCnt
            var0 = new '<>c__DisplayClass1_0'();
            // List<DoSomething> lstOfDelegate = new List<DoSomething>();
            var1 = new List<DoSomething>();
            // int iCnt = 0;
            var0.iCnt = 0;
            goto IL_003b; // while (iCnt < 10) {
    IL_0016:
            // lstOfDelegate.Add(delegate { Console.WriteLine(iCnt); });
            var1.add(new DoSomething(var0, funcPtr('<>c__DisplayClass1_0'.'<Main>b__0')));
            // iCnt++;
            var2 = var0.iCnt;
            var0.iCnt = var2 + 1;
    IL_003b:
            var3 = var0.iCnt < 10;
            if (var3) goto IL_0016; // }
            var4 = var1.GetEnumerator();
            goto IL_0067; // foreach (var item in lstOfDelegate) {
            try {
    IL_0054:
            var5 = var4.Current;
            var5.Invoke();
    IL_0067:
            if (var4.MoveNext()) goto IL_0054;
            } finally {
            var4.Dispose();
            
            }
            Console.ReadLine();
        }
        public Program() { /* Default constructor */ }
    }
