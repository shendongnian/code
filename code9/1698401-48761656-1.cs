    var json = "{\"firstname\":\"\", \"lastname\":\"Doe\"}";
    		
    var obj = JsonConvert.DeserializeObject<User>(json, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
    		
    Console.WriteLine(obj.Firstname == null); // print out "True"
    Console.WriteLine(obj.Firstname == string.Empty); //print out "False"
