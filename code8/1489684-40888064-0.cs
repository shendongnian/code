    public class MyObject : IComparable
    {
        public MyObject(string name, int level)
        {
            Name = name;
            Level = level;
        }
    
        public string Name { get; }
        public int Level { get; }
    
        public override string ToString()
        {
            return $"{Name}, level {Level}";
        }
    
        public int CompareTo(object obj)
        {
            var myObj = obj as MyObject;
            if (myObj == null) return -1;
    
            int compare = Level - myObj.Level;
            if (compare != 0) return compare;
            
            // objects are in the same order
            // order by name
            return string.Compare(Name, myObj.Name, StringComparison.Ordinal);
        }
    }
