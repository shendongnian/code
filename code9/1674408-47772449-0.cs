    public class exampleJson{
    public string author {get;set;}
    public string description {get;set;}
    .....
    
    }
    var data = JsonConvert.DeserializeObject<exampleJson>(myJSON);
    string authorName = data.author;
    string descriptions = data.description ;
