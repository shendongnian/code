        const string constHello = "Hello";
        void Foo()
        {
            Console.WriteLine({IsReferenceEquals("Hello")}");
        }
        public static bool IsReferenceEquals(string s) => ReferenceEquals(constHello, s);
