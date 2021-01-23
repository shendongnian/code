    string input;
    List<string> s = new List<string>();
    while((input = Console.ReadLine()) != null && input != ""){
       s.Add(input);
    }
    
    foreach(string h in s){
       Console.WriteLine(h);
    }
