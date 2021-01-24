    public class Node : ObservableObject
    {
        private double x;
        public double X
        {
            get { return x; }
            set { Set(() => X, ref x, value); }
        }
        private double y;
        public double Y
        {
            get { return y; }
            set { Set(() => Y, ref y, value); }
        }
        public string Text { get; set; }
        public List<string> NextNodes { get; set; }
        public static ObservableCollection<Node> GetSampleNodes()
        {
            return new ObservableCollection<Node>()
            {
                new Node { X = 300, Y = 100, Text = "n1", NextNodes = new List<string> { "n2", "n4", "n5" } },
                new Node { X = 150, Y = 200, Text = "n2", NextNodes = new List<string> { "n3" } },
                new Node { X =  50, Y = 450, Text = "n3" },
                new Node { X = 200, Y = 500, Text = "n4" },
                new Node { X = 700, Y = 500, Text = "n5" }
            };
        }
    }
