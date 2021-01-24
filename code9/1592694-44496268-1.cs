    class Test
    {
        class MainVariableHolder
        {
            public int i;
            public void fn1() => Console.WriteLine(i);
            public void fn2() => Console.WriteLine(i);
        }
        void Foo()
        {
            var holder = new MainVariableHolder();
            holder.i = 10;
            Action fn1 = holder.fn1;
            holder.i = 11;
            Action fn2 = holder.fn2;
            fn1();
            fn2();
        }
    }
