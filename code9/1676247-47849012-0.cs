    public class SearchBase<T, TResult> where T: ResultBase
    {
        public TResult result { get; set; } 
    }
    public class SearchImp : SearchBase<SearchImp, ResultImp>
    {
        public TResult result { get; set; }
    }
    public class ResultBase
    {
    }
    public class ResultImp : ResultBase
    {
        
    }
