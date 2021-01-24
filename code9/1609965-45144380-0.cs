    class MyRoot
    {
        public Node[] Categories {get;set;}
    }
    
    class Node
    {
        public string Code{get;set;}
        public string Name {get;set;}
        public Node[] Children{get;set;}
    }
    var myRoot=JsonConvert.DeserializeObject<MyRoot>(someString);
    Console.WriteLine(myroot.Categories[0].Children[3].Name);
    ------
    Walkers
