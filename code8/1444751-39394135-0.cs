        var commonValue = new Value { Id = 1, SomeValue = "Test" };
        var list1 = new List<MyClass>
        {
            new MyClass
            {
                Id = 1,
                Name = "Name 1",
                Values = new List<Value>
                {
                    commonValue
                }
            }
        };
        var list2 = new List<MyClass>
        {
            new MyClass
            {
                Id = 1,
                Name = "Name 1",
                Values = new List<Value>
                {
                    commonValue,
                    new Value {Id = 2, SomeValue = "Test" }
                }
            }
        };
