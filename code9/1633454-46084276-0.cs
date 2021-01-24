        string[] permittedValues = {"Historical","Correspondence","Archived"};
		string input = "Historical Vol2";
        string val = permittedValues.FirstOrDefault(v => input.StartsWith(v)); // this will be null if there's no match.
        if (val == null) {
            Console.WriteLine("not permitted");
        }
        else {
    		Console.WriteLine(val); // prints "Historical" 
        }
