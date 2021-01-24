    public class Answer
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string TextAnswer { get; set; }
        // added in model
        public Question Question { get; set; }
    } 
