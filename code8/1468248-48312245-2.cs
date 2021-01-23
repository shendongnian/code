      public class Tree<T>
      {
        private readonly List<T> list;
    
        private static readonly Func<List<T>, int, Node<T>> LeftFunc = (l, i) =>
        {
          var lix = Convert.ToInt32(Convert.ToString(i, 2) + "0", 2) - 1;
          return l.Count > lix ? new Node<T> {Data = l[lix], Left = LeftFunc(l, lix + 1), Right = RightFunc(l, lix + 1) } : null;
        };
    
        private static readonly Func<List<T>, int, Node<T>> RightFunc = (l, i) =>
        {
          var rix = Convert.ToInt32(Convert.ToString(i, 2) + "1", 2) - 1;
          return l.Count > rix ? new Node<T> { Data = l[rix], Left = LeftFunc(l, rix + 1), Right = RightFunc(l, rix + 1) } : null;
        };
    
        public Node<T> Root => list.Any() ? new Node<T>{Data=list.First(), Left = LeftFunc(list,1), Right= RightFunc(list,1)} : null;
    
        public Tree(params T[] data)
        {
          list = new List<T>(data);
        }
    
        public int Count => list.Count;
    
        public void AddNodes(params T[] data)
        {
          list.AddRange(data);
        }
    
        public IEnumerable<T> Values => list.ToArray();
    
        public double Levels => Math.Floor(Math.Log(list.Count,2))+1;
    
        public override string ToString()
        {
          return  (list?.Count ?? 0).ToString();
        }
      }
