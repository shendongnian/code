        class Map
        {
            public static Dictionary<string, Map> dict = new Dictionary<string, Map>();
            string name { get; set; }
            long address { get; set; }
            Type _type { get; set; }
        }
