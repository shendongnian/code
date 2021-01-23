    public class Test
    {
        private int foo()
        {
            return nested.foo();
        }
        private int calculateSomeValue()
        {
            return 42;
        }
        readonly Nested nested = new Nested();
        private class Nested
        {
            private int j;
            public int foo()
            {
                int i = calculateSomeValue() + j;
                j = i;
            }
        }
    }
