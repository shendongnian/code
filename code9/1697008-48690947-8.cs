    void Main()
    {
    	string jsonString = @"{
        ""name"": ""foo"",
        ""value"": [ [ 1.2, 2.3, 4.5 ], [ 1.2, 2.3, 4.5 ] ]
        }";
    
    	Console.WriteLine(ParseFoo(jsonString));
    	jsonString = @"{
        ""name"": ""foo"",
        ""value"": [ 1.2, 2.3, 4.5 ]
        }";
    
    	Console.WriteLine(ParseFoo(jsonString));
    
    	jsonString = @"{
        ""name"": ""foo"",
        ""value"": 2.7
        }";
    
    	Console.WriteLine(ParseFoo(jsonString));
    }
