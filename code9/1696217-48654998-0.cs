    public class Node
    {
        public string name { get; }
        public List<int> someList { get; set; }
        public Node(string s, List<int> i)
        {
            name = s;
            someList = i;
        }
        public void add(int i)
        {
            someList.Add(i);
        }
        public void remove(int i)
        {
            someList.Remove(i);
        }
    }
