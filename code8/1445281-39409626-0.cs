    public static class MyClass
    {
        static MyClass()
        {
            Number = 2;
        }
    
        public static int Number { get; set; } //might also be a field, of course
    
        public static void Construct(int number)
        {
            Number = number;
        }
    }
