    string output = "";
    string input = "The texts starts here **Get This String **Some other text ongoing here.....";
    var splits = input.Split( new string[] { "**", "**" }, StringSplitOptions.RemoveEmptyEntries );
    if ( splits.Length >= 2 )
        output = splits[1];
    Console.Write( output );
    Console.ReadKey();
