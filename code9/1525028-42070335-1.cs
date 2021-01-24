    public class MyTestAttribute : ValidationAttribute
    {
        private readonly string _regex1;
        private readonly string _regex2;
        public MyTestAttribute(string regex1, string regex2)
        {
            _regex1 = regex1;
            _regex2 = regex2;
        }
        public override bool Match(object obj)
        {
            var input = (string) obj;
            //here is your check.
            
        }
    }
