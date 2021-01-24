    public class Forum
    {
        public int Id {get; set;}
        public IEnumerable<Topic> Topics {get; set;}
    }
    public class Topic
    {
        public int Id {get; set;}
        public Forum Forum {get; set;}
    }
