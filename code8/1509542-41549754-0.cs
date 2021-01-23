        public class StatsBySeason
        {
            public int Season { get; set; }
            public StatLines StatLines { get; set; }
            public string SeasonYears => Season + " / " + (Season + 1);
        }
