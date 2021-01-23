        void Print();
    }
    public class GenericClassWithConstraint<T> where T : IPrintable
    {
        public T MyProperty { get; set; }
        void Print()
        {
            MyProperty.Print();
        }
    }
