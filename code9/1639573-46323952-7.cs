    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                string key = PrepareConstant(1, false);
                MyConstant val = (MyConstant)Enum.Parse(typeof(MyConstant), key, true);
                Dictionary<string, MyConstant> dict = new Dictionary<string, MyConstant>
                {
                    { key, val},
                };
    
                Console.WriteLine(dict[key]); // output: LifeBand1Standard
    
                Console.ReadKey();
            }
    
            static string PrepareConstant(int band, bool isMultiLife)
            {
                var constantName = "Life";
                constantName += "Band" + band;
                constantName += (isMultiLife) ?  "Multi" : "Standard";
    
                return constantName;
            }
        }
    
        public enum MyConstant
        {
            LifeBand1Standard = 78,
            LifeBand1Multi = 61,
            LifeBand2Standard = 71,
            LifeBand3Standard = 62,
            TrumaBand2Multi = 56,
            TrumaBand3Multi = 48
        }
    }
