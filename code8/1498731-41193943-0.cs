    public class QuestionOrderComparerFactory : IQuestionOrderComparerFactory
    	{
    		private IRepository<Question> _questions;
    		
    		public QuestionOrderComparerFactory(IRepository<Question> questions)
    		{
    			_questions = questions;
    		}
    		
    		public QuestionOrderComparer Create()
    		{
    			return new QuestionOrderComparer(_questions);
    		}
    		
    	}
    	
    	thisSetOfApplicantQuestions.OrderBy(x => x.QuestionId, _comparerFactory.Create()); // comparer factory is injected via constructor
