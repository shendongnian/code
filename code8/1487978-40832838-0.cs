    public class GenericClass<T>
    {
        public T MyProperty { get; set; }
        public void TestMethod()
        {
            Console.WriteLine(MyProperty.ToString());
        }
    }
