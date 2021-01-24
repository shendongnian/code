    public class Vote
    {
      [Key, Column(Order = 0)]
      public string UserID { get; set; }
    
      [Key, Column(Order = 1)]
      public int QuestionID { get; set; }
    }
