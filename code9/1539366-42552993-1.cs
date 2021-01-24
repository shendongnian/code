        public class Father { }
        public class Child_A : Father, IMethodOwner { public void Method_A() { }}
        public class Child_B : Father{ }
        public interface IMethodOwner { void Method_A(); }
        public class MyClass
        {
            public Father dynamicObject;
            public void MyMethod() {
                var obj = dynamicObject as IMethodOwner;
                if(obj != null)
                    obj.Method_A();
            }
        }
