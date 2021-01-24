    public class OldQuestionItem
    {
      public DateTime UploadTimeStamp {get; set;} //if less then DateTime.Now then it QuestionItem 
      public string Property1 {get; set; }
      public string Property2 {get; set; }
      ...
     
      public OldQuestionItem(NewQuestionItem newItem)
      {
         //logic to convert new in old
      }
    }
    public class NewQuestionItem : OldQuestionItem
    {
        
    }
