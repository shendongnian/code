    interface IFoo
    {
        string Foo { get; }
    }
    interface IBar
    {
        void Bar();
    }
    class BarAndFoo: IFoo, IBar
    {
       public int OtherProperty { get; set; } // not defined in any interface
        public string Foo { get; set; } // complies with IFoo
        public void Bar() // complies with IBar
        {
        }
    }
