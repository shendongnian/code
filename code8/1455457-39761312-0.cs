    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test();
            try
            {
                test.TriggerError();
            }
            catch(Exception ex)
            {
                var trace = new StackTrace(ex, true);
                var frame = trace.GetFrames().Last();
                var lineNumber = frame.GetFileLineNumber();
                var fileName = frame.GetFileName();
            }
            
        }
    }
    class Test
    {
        public void TriggerError()
        {
            throw new Exception();
        }
    }
