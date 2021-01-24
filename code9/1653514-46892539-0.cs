       public class Case
        {
            public string name { get; set; }
        }
        public class Myclass
        {
            public Myclass(string name) { C = new Case(); C.name = name; }
            public Case C { get; set; }
        }
        class Hello
        {
            static void Main()
            {
                Myclass obj = new Myclass("Testing");
                string val = obj.C.name;
                Console.WriteLine(val);
                Console.ReadLine();
            }
        }
