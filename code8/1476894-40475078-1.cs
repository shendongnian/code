    public class HtmlQuestionConverter
    {
    	public HtmlQuestionConverter() 
    	{
    		TypeToConvertMap = new Dictionary<Type, Action<Question, HtmlTextWriter>>
    		{
    			{ typeof(TrueFalseQuestion), new Action<Question, HtmlTextWriter>(ConvertTrueFalseToHtml) }
    			// other mappings...
    		};
    	}
    	
    	private Dictionary<Type, Action<Question, HtmlTextWriter>> TypeToConvertMap
    	{
    		get;
    	}
    
    	public void ConvertToHtml(IEnumerable<Question> questions, HtmlTextWriter htmlWriter)
    	{
    		foreach (Question question in questions)
    		{
                // Calls the appropiate method to turn the question
                // into HTML using found delegate!
    			TypeToConvertMap[question.GetType()](question, htmlWriter);
    		}
    	}
    
    	private void ConvertTrueFalseToHtml(Question question, HtmlTextWriter htmlWriter)
    	{
    	    // Code to write the question to the HtmlTextWriter...
    	}
    }
