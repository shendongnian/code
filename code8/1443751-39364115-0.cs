    class Foo
    {
    	public const string BarDefault = "foobar";
    	public string Bar { get; set; } = BarDefault;
    }
    
    var foo = new Foo { Bar = bar ?? Foo.BarDefault };
