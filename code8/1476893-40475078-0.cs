    public class XmlQuestionConverter
    {   
        public XmlQuestionConverter() 
    	{
    		TypeToConvertMap = new Dictionary<Type, Action<Question, XElement>>
    		{
    			{ typeof(TrueFalseQuestion), new Action<Question, XElement>(ConvertTrueFalseFromXml) }
    			// other mappings...
    		};
    	}
    	private Dictionary<Type, Action<Question, HtmlTextWriter>> TypeToConvertMap
    	{
    		get;
    	}
         // This dictionary maps element names to their type
         private Dictionary<string, Type> QuestionTypeMap { get; } = new Dictionary<string, Type>()
         {
              { "truefalse", typeof(TrueFalseQuestion) },
              { "multichoice", typeof(MultiChoiceQuestion) }
              // And so on
         };
    
         public IList<Question> ConvertFromXml(XDocument questionsDocument)
         {
            // This will get all question elements and it'll project them
            // into concrete Question instances upcasted to Question base
            // class
            List<Question> questions = questionsDocument
                         .Descendants("question")
                         .Select
                         (
                            element =>
                            {
                               Type questionType = QuestionTypeMap[q.Attribute("type").Value];
                               Question question = (Question)Activator.CreateInstance(questionType);
                               // Calls the appropiate delegate to perform specific
                               // actions against the instantiated question
                               TypeToConvertMap[questionType](question, element);
                               return question;
                            }
                         ).ToList();
    
            return questions;
         }
         private void ConvertTrueFalseFromXml(TrueFalseQuestion question, XElement element)
         {
              // Here you can populate specific attributes from the XElement
              // to the whole typed question instance!
         }
    }
