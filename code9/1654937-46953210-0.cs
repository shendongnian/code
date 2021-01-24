        static void Main(string[] args)
        {
            List<Obvious> list = new List<Obvious>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new Obvious(i.ToString(), i));
            }
            string name = list[30].name;
            switch (name)
            {
                case "9":
                    list.OrderBy(o => o.perc)
                        .ThenByDescending(o => o.name);
                    break;
                default:
                    list.OrderByDescending(o => o.name)
                        .ThenBy(o => o.perc);
                    break;
            }
        }
        public class Obvious
        {
            public string name { get; set; }
            public int perc { get; set; }
            public Obvious(string _name, int _perc)
            {
                this.name = _name;
                this.perc = _perc;
            }
            
        }
