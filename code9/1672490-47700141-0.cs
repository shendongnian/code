    class Program
    {
        static void Main(string[] args)
        {
            var test = Get("yes");
        }
        public static object Get(string value)
        {
            List<Obj1> List1 = new List<Obj1>();
            List1.Add(new Obj1());
            List<Obj2> List2 = new List<Obj2>();
            List2.Add(new Obj2());
            return (from om in List1
                    where List2.Any(ol => ol.prop == value)
                    select om.prop).FirstOrDefault();
        }
    }
    public class Obj1
    {
        public string prop => "not";
    }
    public class Obj2
    {
        public string prop => "yes";
    }
