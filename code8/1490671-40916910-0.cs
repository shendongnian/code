    public class QuestionClass<T> where T : AnswerClass
    {
    	private string question;
    	private T answer;
    
    	public string Question
    	{
    		get { return question; }
    		set { question = value; }
    	}
    
    	public T Answer
    	{
    		get { return answer; }
    		set { answer = value; }
    	}
    
    	public QuestionClass(string question, T answer)
    	{
    		this.question = question;
    		this.answer = answer;
    	}
    }
