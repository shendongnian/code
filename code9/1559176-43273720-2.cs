    string output = "";
    string input = "The texts starts here **Get This String **Some other text ongoing here..";
    var splits = input.Split( new string[] { "**", "**" }, StringSplitOptions.None );
    //Check if the index is available 
    //if there are no '**' in the string the [1] index will fail
    if ( splits.Length >= 2 )
        output = splits[1];
    Console.Write( output );
    Console.ReadKey();
