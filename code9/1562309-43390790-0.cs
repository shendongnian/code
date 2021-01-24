    public class ResultGetter
    {
        private readonly string _code;
        public ResultGetter(string code)
        {
            _code = code;
        }
        public string GetResult1()
        {
            var returnValue = // do something with _code property    
            return returnValue; 
        }
        public string GetResult2()
        {
            var returnValue = // do something with _code property
            return returnValue;
        }
        // et cetera ad nauseam
    }
