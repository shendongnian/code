    To read a Dictionary --
    foreach(KeyValuePair<string,string> kvp in p){
         Console.WriteLine(kvp.Key);
         Console.WriteLine(kvp.Value);
     }
     foreach(string key in p.Keys){
        Console.WriteLine(key);
        Console.WriteLine(p[key]);//value
     }
    foreach(string value in p.Values){
        Console.WriteLine(value);
    }
