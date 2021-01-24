    public class xyz
    {
        private readonly IChecker checker;
        public xyz()
        {
            // default constructor initialization
            _checker = checker.Create<xyz>();
        };
        public xyz(string value) : this()
        {
            // parameterized Constructor
            validateIt(value);
            //do something
        }
        private void validateIt(string value)
        {
            var msg= "Is not Valid";
            _checker.log(msg);
        }
    }
