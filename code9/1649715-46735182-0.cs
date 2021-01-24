    var data = new[] {
    	new Something {SomeIntProperty=1, SomeStringProperty="A"}
    ,   new Something {SomeIntProperty=2, SomeStringProperty="A"}
    ,   new Something {SomeIntProperty=3, SomeStringProperty="A"}
    ,   new Something {SomeIntProperty=4, SomeStringProperty="A"}
    ,   new Something {SomeIntProperty=5, SomeStringProperty="A"}
    ,   new Something {SomeIntProperty=6, SomeStringProperty="B"}
    ,   new Something {SomeIntProperty=7, SomeStringProperty="B"}
    ,   new Something {SomeIntProperty=8, SomeStringProperty="C"}
    ,   new Something {SomeIntProperty=9, SomeStringProperty="D"}
    };
    var dict = data.GroupBy(s => s.SomeStringProperty)
                         .ToDictionary(g => g.Key);
    foreach (var key in dict.Keys) {
    	if (data.Any(s => ReferenceEquals(s.SomeStringProperty, key))) {
    		Console.WriteLine("Key '{0}' is present.", key);
    	} else {
    		Console.WriteLine("Key '{0}' is not present.", key);
    	}
    }
