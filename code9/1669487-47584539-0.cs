    public class MyClass
    {
        static int test = 5;
        [CustomAttribute(Parameter = test)]
        public object Data { get; set; }
    }
