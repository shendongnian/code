    public class Program
    {
        public static void Main()
        {
            Dictionary<int, Info> _dic = new Dictionary<int, Info>();
            _dic.Add(1, new Info()
            {Id = 1, Name = "Pawan"});
            _dic.Add(2, new Info()
            {Id = 2, Name = "Raj"});
            _dic.Add(3, new Info()
            {Id = 3, Name = "Shakya"});
            Console.WriteLine(_dic[1].Name);
            Console.WriteLine(_dic.ContainsKey(1));
            Console.WriteLine(_dic.ContainsValue(new Info(){Id = 3, Name = "Shakya"})); 
        }
        public class Info
        {
            public int Id
            {
                get;
                set;
            }
            public string Name
            {
                get;
                set;
            }
            
            public override int GetHashCode(){
                return Id;
            }
            
            public override bool Equals(object obj)
            {
                if(obj.GetType()==typeof(Info))
                {
                    Info i = obj as Info;
                    return i != null && i.Id == Id && i.Name == Name;
                }
                return false;
            }
        }
    }
