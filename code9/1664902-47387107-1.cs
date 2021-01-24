    {"results": [
    	 {
    	   "key1":"43853",
    	   "key2":"43855",
    	   "key3":"43856",
    	   "key4":"43857",
    	   "question": {
    		 "questionType": 3,
    		 "choiceAnswers": [123]   
    	   }
    	 }
     ]};
     
     public class JsonDto
     {
    	public List<ResultDto> Results { get; set; }
     }
     public class ResultDto
     {
    	public string Key1 { get; set; }
    	public string Key2 { get; set; }
    	public string Key3 { get; set; }
    	public string Key4 { get; set; }
    	public QuestionDto Question { get; set; }
     }
     public class QuestionDto
     {
    	public int QuestionType { get; set; }
    	public List<int> ChoiceAnswers { get; set; }
     }
     
