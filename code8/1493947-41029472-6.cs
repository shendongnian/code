    public class Animal
    {
         public string Name { get; set; }
         public int Monday { get; set; }
         public int Tuesday { get; set; }
    }
    
    var zooDict = new Dictionary<string, List<Animal>>();
    // then in your while loop you do this 
    if(!zooDict.ContainsKey(location))
        zooDict[location] = new List<Animal>();
    zooDict[location].Add(new Animal() { /* fill Monday and Tuesday properties */ });
