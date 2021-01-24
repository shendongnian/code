        public class Test
        {
            public int A { get; private set; }
            public int b { get; private set; }
            public Test(int a, int b)
            {
                this.A = a;
                this.b = b;
            }
        };
    Only the getters need be public for Json.NET to serialize them. 
