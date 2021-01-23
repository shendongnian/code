    public class QuestionAndAnswerNewMarge
    {
    	public List<Question> Questions { get; set; }
    	public List<Answer> Answers { get; set; }
    }
    
    public class Question
    {
    	public int QuestionID { get; set; }
    	public string QuestionText { get; set; }
    	public bool IsMultiple { get; set; }
    }
    public class Answer
    {
    	public int QuestionID { get; set; }
    	public int AnswerID { get; set; }
    	public string AnswerText { get; set; }
    }
