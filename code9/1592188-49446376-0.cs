    [Serializable]
    public class TreeviewNodeEntity
    {
        public string text { get; set; }
        public string[] tags { get; set; }
        public TreeviewNodeEntity[] nodes { get; set; }
    }
