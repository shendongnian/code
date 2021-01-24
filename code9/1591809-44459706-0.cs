    public void Foo()
        {
            var x = 0;
            Bar(x); // x still equals 0
            Bar(ref x); // x now equals 1
        }
        public void Bar(ref int x)
        {
            x = 1;
        }
        public void Bar(int x)
        {
            x = 1;
        }
