        public static void Main(string[] args)
        {
            TestClass t1 = new TestClass() { ID = 1 };
            MyClass<TestClass> myClassObject = new MyClass<TestClass>(t1);
            Test(myClassObject);
        }
        public static void Test<T>(MyClass<T> obj)where T: TestClass
        {
            Console.WriteLine(obj.TestClassObject.ID);
        }
        public class TestClass
        {
            public int ID { get; set; }
        }
        public class MyClass<T> where T:TestClass
        {
            public MyClass(T obj)
            {
                TestClassObject = obj;
            }
            public T TestClassObject
            {
                get;
                set;
            }
        }
