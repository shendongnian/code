    public class GreatClass
    {
        public IDictionary<string, IDictionary<string, IDictionary<string, MetadataJSON>[]>> url { get; set; }
        public partial class MetadataJSON
        {
            public string innerHTML { get; set; }
            public string nodeName { get; set; }
            public int treeDepth { get; set; }
            public string className { get; set; }
            public int childNodesLength { get; set; }
            public int childrenLength { get; set; }
            public Nullable<int> height { get; set; }
            public int clientHeight { get; set; }
            public string parentNodeName { get; set; }
            public int parentChildNodesLength { get; set; }
            public string name { get; set; }
        }
    }
