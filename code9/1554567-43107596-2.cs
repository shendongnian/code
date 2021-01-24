            for(int i = 0; i < d.Count(); i++)
            {
                Console.WriteLine(g[i].groupName);
            }
            Console.ReadLine();
        }
    }
    public class groupOptions
    {
        
        public string groupName { get; set; }
    }
    class dataIndicator
    {
        public int headerID { get; set; }
        public string indicatorDescription { get; set; }
    }
