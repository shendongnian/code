    //Initialization of Dictonary
    obj.namedTypes.Menu.fields = new Dictionary<string,string>();
    //Reading from File and iteration on matches
    MatchCollection matches = reg.Matches(File.ReadAllText("test.txt"));
    string description;
    string value;
    foreach (Match m in matches)
    {
       description = m.Groups["Description"].ToString();
       value = m.Groups["Identifier"].ToString();
       obj.namedTypes.Menu.fields.Add(description , value);
    }
    //End: Serialize the Whole stuff
    Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented));
