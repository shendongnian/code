    public class Port
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Desc);
        }
    }
