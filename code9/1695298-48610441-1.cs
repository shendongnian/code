        public class Parent {}
        public class Child : Parent 
        {
            private void someMethod() {}
        }
        ...
        dynamic person = new Child();
        person.someMethod(); // would cause run-time error if someMethod is absent at Child
