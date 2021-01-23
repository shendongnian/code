        public abstract class QuestionClass { 
        
        }
        
        public class QuestionClass<T> : QuestionClass where T: AnswerClass
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
    
    And usage like this:
    
    void Main()
    {
    	var ra = new RangedAnswer();
    	ra.LowerBound = 10;
    	ra.UpperBound = 20;
    	
    	var na = new NumericalAnswer();
    	na.Answer = 25;
    	
    	var q1 = new QuestionClass<RangedAnswer>("Test range?", ra);
    	var q2 = new QuestionClass<NumericalAnswer>("Numberic?", na);
    	
    	var list = new List<QuestionClass>();
    	list.Add(q1);
    	list.Add(q2);
    
    	foreach (var q in list)
    	{
    		var rat = q as QuestionClass<RangedAnswer>;
    		if (rat != null) {
    			rat.Answer.LowerBound.Dump();
    		}
    		var nat = q as QuestionClass<NumericalAnswer>;
    		if (nat != null) {
    			nat.Answer.Answer.Dump();			
    		}
    	}
    }
