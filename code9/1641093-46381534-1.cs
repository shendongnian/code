    public class GetOnlyProperty
    {
        private readonly string _thing;
        public string Thing => _thing;
    
        public GetOnlyProperty(string thing)
        {
            _thing = thing;
        }
    }
