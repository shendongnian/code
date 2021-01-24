    void Main()
    {
	    var questions = new List<Question>()
	    {
		    new Question() { Id = 1 },
		    new Question() { Id = 2, ParentId = 1 },
		    new Question() { Id = 3, ParentId = 1 },
		    new Question() { Id = 4, ParentId = 2 },
		    new Question() { Id = 5 }
	    };
	    var orderedQuestions = new List<Question>();
	    AddOrderedChildren(questions, orderedQuestions, null);
	
	    foreach(var question in orderedQuestions)
	    {
		question.Id.Dump();
	    }
    }
    public void AddOrderedChildren(List<Question> questions, List<Question> 
    orderedQuestions, int? parentId)
    {
	    foreach(var question in questions.Where(q => q.ParentId == 
        parentId).OrderBy(q=>q.Id))
	    {
		    orderedQuestions.Add(question);
		    AddOrderedChildren(questions, orderedQuestions, question.Id);
	    }
    }
    public class Question
    {
	    public int Id {get;set;}
	    public int? ParentId {get;set;}
    }
