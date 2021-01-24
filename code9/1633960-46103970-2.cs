    public class Evan
    {
        public string Search { get; set; }
        public IEnumerable<string> Terms { get; set; }
        public override string ToString()
        {
            return string.Format("Search={0},Terms=[{1}]", 
                Search, string.Join(",", Terms));
        }
    }
