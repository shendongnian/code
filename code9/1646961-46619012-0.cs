        public class Student
        {
            public string Name { get; set; }
            public double Score { get; set; }
        }
        public class Node
        {
            public SortedDictionary<char, Node> Children { get; set; }
            public List<Student> Top10 { get; set; }
        }
        public class StudentIndex
        {
            private Node _root;
            public StudentIndex(IEnumerable<Student> students)
            {
                Node root = new Node();
                foreach(var student in students)
                {
                    var parts = student.Name.Split(new[] {'_'});
                    foreach(var part in parts)
                    {
                        //you'll add each student to the tree using each part of the name    
                    }
                }
                //set _root
            }
            
            public IEnumerable<Student> GetTop10(string s)
            {
                return GetTop10(s.ToLower(), _root);
            }
            private IEnumerable<Student> GetTop10(string s, Node node)
            {
                if (node.Children == null) return node.Top10;
                if (s.Length == 0) return node.Top10;
                var c = s[0];
                Node n;
                if (node.Children.TryGetValue(c, out n))
                {
                    return GetTop10(s.Substring(1), n);
                }
                else
                {
                    return Enumerable.Empty<Student>();
                }
            }
        }
