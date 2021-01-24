    class SomeClass {
        public Int32 SomeProperty { get; set; }
    }
    
    SomeClass[] arr = new [] {
        new SomeClass { SomeProperty = 99 },
        new SomeClass { SomeProperty = 98 },
        new SomeClass { SomeProperty = 92 },
        new SomeClass { SomeProperty = 97 },
        new SomeClass { SomeProperty = 95 }
    }
    
    SomeClass[] newArr = (SomeClass[])arr.Clone();
    
    newArr[0].SomeProperty = 100;
    
    Console.WriteLine(arr[0].SomeProperty);
