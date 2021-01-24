    interface IPet {
        ...
    }
    class Dog : IPet {
        ...
    }
    class Cat : IPet {
        ...
    }
    class Person {
        public IPet Pet { get; set; }
    }
