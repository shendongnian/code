    public class Result
    {
        public object Value {get; set;}
    }
    public interface IYourTask
    {
        public Result Execute();
    }
    public class StringManipulationTask
    {
        public Result Execute()
        {
            // do something
            return new Result(); // with some data or not
        }
    }
    
    public class CalculationTask
    {
        public Result Execute()
        {
            // do something
            return new Result(); // with some data or not
        }
    }
