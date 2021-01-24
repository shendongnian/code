    public class A : ISomething
    {
        public A(ISomething input)
        {
            A.MyProperty = input.MyProperty;
            A.AnotherProperty = somethingNotFromTheInterface
        }
    }
