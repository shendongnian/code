    static void UseDynamicObject()
    {
    
    	var colorProperty = "Color";
    	var ageProperty = "Age";
    
    	dynamic dynamo = new Dynamo();
    	dynamo.colorProperty = "red";
    	dynamo[ageProperty] = 20;
    
    	// DOT-PROPERTY NOTATION
    	// Error: Microsoft.CSharp.RuntimeBinder.RuntimeBinderException:
    	// 'Dynamo' does not contain a definition for 'Color'.
    	Console.WriteLine(dynamo.Color);
    	// The property used to retrieve value "red" is "colorProperty" rather "Color".
    	Console.WriteLine(dynamo.colorProperty);
    
    	// INDEXER NOTATION
    	// We can use either variable or literal name of the property,
    	// so these two lines are equivalent.
    	Console.WriteLine(dynamo[ageProperty]);
    	Console.WriteLine(dynamo["Age"]);
    
    }
