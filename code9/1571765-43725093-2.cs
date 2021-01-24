    public class Result
    {
        public object Value {get; set;}
    }
    public interface IYourTask
    {
        Result Execute();
    }
    public class StringManipulationTask
    {
        public Result Execute()
        {
            // do something
            return new Result("resultofManipulation");
        }
    }
    
    public class NoReturnDataTask
    {
        public Result Execute()
        {
            // do something
            return new Result(); // with no data - "empty result"
        }
    }
