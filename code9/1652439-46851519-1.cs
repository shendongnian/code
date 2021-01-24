        public class Bar
        {
            public void Foo<T>(T data) where T : TestClass
            {
    
                   (int first, int second) = data;
    
                   //do stuff with tuples
             }
        }
