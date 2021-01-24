    public class C
    {
        [CompilerGenerated]
        private sealed class <>c__DisplayClass0_0
        {
            public uint counter;
            internal void <M>b__0(int a)
            {
                uint num = this.counter + 1u;
                this.counter = num;
            }
        }
        public void M()
        {
            C.<>c__DisplayClass0_0 <>c__DisplayClass0_ = new C.<>c__DisplayClass0_0();
            <>c__DisplayClass0_.counter = 65535u;
            List<int> source = new List<int> {
                1,
                2,
                3
            };
            source.AsParallel<int>().ForAll(new Action<int>(<>c__DisplayClass0_.<M>b__0));
        }
    }
