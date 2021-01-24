    public class Program
        {
            public static void Main(string[] args)
            {
                //Your code goes here
                Console.WriteLine("Hello, world!");
                List<string> strings;
                strings = new List<string>()
                {
                    "Root1.Parrent1",
                    "Root1.Parrent2",
                    "Root1.Parrent3.Child1",
                    "Root1.Parrent4.Child2",
                    "Root2.newParrent1.newChild1",
                    "Root2.newParrent1.newChild2",
                    "Root2.NewParrent2"
                };
                eat e = new eat(strings);
                Console.WriteLine(e.root.ToJson());
                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
            }
        }
        public class eat
        {
            public node root;
            public eat(List<string> l)
            {
                root = new node("root");
                foreach(string s in l)
                {
                    addRow(s);
                }
    
            }
            public void addRow(string s)
            {
                List<string> l = s.Split('.').ToList<String>();
                node state = root;
                foreach(string ss in l)
                {
                    addSoon(state, ss);
                    state = getSoon(state, ss);
                }
            }
            private void addSoon(node n, string s)
            {
                bool f = false;
                foreach(node ns in n.soon)
                {
                    if (ns.name == s) { f = !f; }
                }
                if (!f) { n.soon.Add(new node(s)); }
                
            }
            private node getSoon(node n,string s)
            {
                foreach (node ns in n.soon)
                {
                    if (ns.name == s) { return ns; }
                }
                return null;
            }
        }
        public class node
        {
            public node(string n)
            {
                name = n;
                soon = new List<node>();
            }
            public string name;
            public List<node> soon;
    
            public string ToJson()
            {
                String s = "";
                s = s + "{\"name\":\"" + name + "\",\"soon\":[";
                bool f = true;
                foreach(node n in soon)
                {
                    if (f) { f = !f; } else { s = s + ","; }
                    s = s + n.ToJson();
                }
                s = s + "]}";
                return s;
            }
        }
