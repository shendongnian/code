    var p = new { Prop1 = "value 1", Prop2 = 123 };
    dynamic obj = p.Extend();
    Console.WriteLine(obj.Prop1);           // Value 1
    Console.WriteLine(obj.Prop2);           // 123
    Console.WriteLine(obj.SomeExtension);   // Some Value
