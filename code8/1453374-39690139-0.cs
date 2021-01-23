    public class NameObject
    {
        public string[] Names { get; set; }
        public string Name
        {
            get { return (Names != null && Names.Length > 0) ? Names[0] : null; }
            set { Names = (value != null) ? new string[] { value } : null; }
        }
    }
