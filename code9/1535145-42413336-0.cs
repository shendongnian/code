        public class BaseClass
        {
            public int MyProperty { get; set; }
        }
        public class Derived : BaseClass
        {
            public string AnotherProperty { get; set;}
            public Derived(BaseClass b)
            {
                this.MyProperty = b.MyProperty;
                this.AnotherProperty = "MyValue";
            }
        }
