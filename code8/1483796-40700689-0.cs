    class Program
    {
        static void Main(string[] args)
        {
            object obj = FormatterServices.GetUninitializedObject(typeof(A));
            obj.GetType().GetProperty("I").SetValue(obj, 1);
            obj.GetType().GetConstructor(Type.EmptyTypes).Invoke(obj, null);
            Console.WriteLine("Done");
        }
    }
    class A
    {
        public A()
        {
            if (I != 0)
            {
                Console.WriteLine("Who set me? I = {0}", I);
            }
        }
        public int I { get; set; }
    }
