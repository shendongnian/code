    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
	    private static int[] categoryIds = new int[] {1, 2, 3, 4, 5};
	    private static int[] questionsPerCategory = {3, 1, 6, 11, 7};
        //Part of demo
	    private static IEnumerable<QuestionVM> Questions = Enumerable.Range(0,100).Select(x=> new QuestionVM { Question = $"Question - {x}", CategoryId = (x % 5) + 1});
	
	
	    public static void Main()
	    {
		    var questions = Questions.Where(x=> x.InTest).GroupBy(x=> x.CategoryId).SelectMany(x=> x.OrderBy(y=> Guid.NewGuid()).Take(GetQuestionTake(x.Key)));
		    foreach(var question in questions)
		    	Console.WriteLine($"{question.Question} - CategoryId: {question.CategoryId}");	
	    }
	
	    ///Finds out how many questions it should take by doing a search and then picking the element in the same position
	    private static int GetQuestionTake(int categoryId)
	    {
	    	int element =  categoryIds.Select((x, i) => new { i, x }).FirstOrDefault(x => x.x == categoryId).i;
		    return questionsPerCategory.ElementAtOrDefault(element);
	    }
    }
    //Part of demo
    public class QuestionVM
    {
	    public string Question {get;set;}
	    public int CategoryId {get;set;}	
	    public bool InTest {get;set;} = true;
    }
