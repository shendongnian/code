    public struct foo
        {
            private int _bar;
            public int bar
            {
                [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
                get { return _bar; }
                [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
                set { _bar = value; }
            }
        }
