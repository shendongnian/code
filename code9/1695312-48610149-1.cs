    public class Rootobject
    {
    public Question[] question { get; set; }
    }
    
    public class Question
    {
    public string title { get; set; }
    public Answers answers { get; set; }
    }
    
    public class Answers
    {
    public string correct { get; set; }
    public string[] wrong { get; set; }
    }
