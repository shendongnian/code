    // this is an example
    public class SearchCriteria
    {
       public string Keyword {get;set;}
       public string From {get;set;}
       public string To {get;set;}
    }
    public class Parser
    {
       public SearchCriteria Parse(string searchExpression)
       {
           var keyword = string.Empty;
           var from = DateTime.Min;
           var to = DateTime.Max;
           // To do
           // ... parse your string here
           //
           return new SearchCriteria(){Keyword = keyword, From = from, To = to};
       }
    }
