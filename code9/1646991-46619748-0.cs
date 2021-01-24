    class Program
    {
        static void Main(string[] args)
        {
            Solver s = new Solver();
            s.Solve("++[>+[>++<-]<-]++[>++<-]>.");
            s.Visualize();
            Console.Read();
        }
    }
    
    public class Solver
    {
        private readonly List<int> rightBracketsIds;
        private readonly List<int> leftBracketsIds;
        private readonly List<Tuple<int, int>> lsTuples;
        public Solver()
        {
            rightBracketsIds = new List<int>();
            leftBracketsIds = new List<int>();
            lsTuples = new List<Tuple<int, int>>();
        }
        public void Solve(string s)
        {
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '[':
                        st.Push(i);
                        break;
                    case ']':
                        int index = st.Any() ? st.Pop() : -1;
                        lsTuples.Add(new Tuple<int, int>(index, i));
                        break;
                }
            }
        }
        public void Visualize()
        {
            foreach (Tuple<int, int> tuple in lsTuples)
            {
                Console.WriteLine(tuple.Item1 + " " + tuple.Item2);
            }
        }
    }
