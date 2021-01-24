    public class ListQuery : IQuery<List<string>>
    {
        private string _input;
    
        public ListQuery(string input)
        {
           _input= input;
        }
        public List<string> Execute()
        {
            return new List<string>() { _input };
        }
    }
