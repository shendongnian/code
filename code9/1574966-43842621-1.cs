        public A(ISomething input)
        {
            A.MyProperty = new MyType(input.MyProperty);
            A.AnotherProperty = somethingNotFromTheInterface
        }
