    public class App 
    {
        private IResult<long> result;
    
        public void Run()
        {
            result = new ResultLong();
            result.Increment(500);
        }
    }
