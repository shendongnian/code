    static class Program
    {
        static void Main(string[] args)
        {
            List<Abc> list = new List<Abc>()
            {
                new Abc()
                {
                    a = 5,
                    b = 6,
                    s = "Phew"
                },
                new Abc()
                {
                    a = 9,
                    b = 10,
                    s = "Phew"
                },
                new Abc()
                {
                    a = 5,
                    b = 6,
                    s = "Keep"
                },
                new Abc()
                {
                    a = 9,
                    b = 10,
                    s = "Keep"
                },
                new Abc()
                {
                    a = 5,
                    b = 6,
                    s = "Phew"
                },
                new Abc()
                {
                    a = 9,
                    b = 10,
                    s = "Phew"
                },
            };
            list = list.MyDistinct();
        }
        // Extension Method
        public static List<Abc> MyDistinct(this List<Abc> list)
        {
            List<Abc> newList = new List<Abc>();
            foreach (Abc item in list)
            {
                Abc found = newList.FirstOrDefault(x => x.Equals(item));
                if (found == null)
                {
                    newList.Add(item);
                }
                else
                {
                    if (found.s != "Keep" && item.s == "Keep")
                    {
                        newList.Remove(found);
                        newList.Add(item);
                    }
                }
            }
            return newList;
        }
    }
    class Abc
    {
        public int a, b;
        public string s;
        public override bool Equals(object obj)
        {
            Abc other = obj as Abc;
            return a == other.a && b == other.b;
        }
        public override int GetHashCode()
        {
            return a.GetHashCode() ^ b.GetHashCode();
        }
    }
