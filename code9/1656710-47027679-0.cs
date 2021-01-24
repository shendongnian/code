    class Program
    {
        public class Hook : Attribute
        {
            public string Action { get; set; }
    
            public void Talk(string s)
            {
                var prefix = string.IsNullOrEmpty(Action) ? "" : $"{Action} ";
                Console.WriteLine($"{prefix}{s}");
            }
        }
    
        public class A
        {
            [Hook] public string Option1()=> "A1";
            public string Option2() => "A2";
        }
    
        public class B
        {
            [Hook(Action = "Blah")] public string Option1() => "B1";
            [Hook] public string Option2() => "B2";
        }
    
        static void Main(string[] args)
        {
            var things = new List<object>() {new A(), new B()};
            things.SelectMany(t => t.GetType().GetMethods()
                    .Select(m => (method: m, attribute: m.GetCustomAttribute(typeof(Hook), true) as Hook))
                    .Where(h => h.attribute != null)
                    .Select(h => (target: t, hook: h)))
                .ToList()
                .ForEach(v => v.hook.attribute.Talk(v.hook.method.Invoke(v.target, new object[] { }).ToString()));
        }
    }
