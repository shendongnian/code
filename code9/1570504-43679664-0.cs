    var json = @"{
        ""PropertyOne"":{
            ""SubProperty.One"":""SubValue.One""
     },
        ""Property.Two.Three"":""ValueTwo""
     }";
    string result;
    while (true)
    {
        result = Regex.Replace(json, @"(""[^.]+)(\.)(.+"":)", "$1_$3", RegexOptions.IgnoreCase);
        if (json == result)
        {
            break;
        }
        json = result;
    }
    Console.WriteLine(result);
