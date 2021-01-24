    interface IDriveable {}  // IFoo
    class Car : IDriveable { // Foo
        string Name {get; set; }
    }
    class Volkswagen : Car { // Bar
        bool CorrectPolution { get; set; }
    }
