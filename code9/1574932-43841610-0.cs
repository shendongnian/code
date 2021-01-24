        public class Node
        {
            public List<Node> children = new List<Node>();
            public District district { get; set; }
            public void Print()
            {
            }
            public void Register()
            {
            }
        }
        public class District
        {
            string name { get; set;}
            string area { get; set; }
        }
