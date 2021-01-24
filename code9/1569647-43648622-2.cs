        public class WrapObject<T>
        {
            private T _data;
            public WrapObject(T data)
            {
                _data = data;
            }
            public T Data
            {
                get { return _data; }
            }
        }
        public class Hello
        {
            public void SayHello()
            {
                Console.WriteLine("hello world");
            }
        }
        static void Main()
        {
            Hello h = new Hello();
            WrapObject<Hello> wh = new WrapObject<Hello>(h);
            wh.Data.SayHello();
        }
