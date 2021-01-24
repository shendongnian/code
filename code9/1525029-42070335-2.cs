    public class MyTestAttribute : ValidationAttribute
    {
        private readonly Regex _regex1;
        private readonly Regex _regex2;
        public MyTestAttribute(string regex1, string regex2)
        {
            _regex1 = new Regex(regex1);
            _regex2 = new Regex(regex2);
        }
        public override bool Match(object obj)
        {
            var input = (string) obj;
            if (IsUk())
            {
                return _regex1.IsMatch(input);
            }
            return _regex2.IsMatch(input);
        }
        private bool IsUk()
        {
            //is person in UK
        }
    }
