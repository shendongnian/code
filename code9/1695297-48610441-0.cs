        public class Parent
        {
            protected virtual void someMethod() {}
        }
        public class Child: Parent
        {
            protected override someMethod() {}
        }
        ...
        Parent person = new Child();
        person.someMethod(); // would cause compile-time error if someMethod is missed in Parent virtual table
