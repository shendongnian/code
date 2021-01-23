        public class Metrics
        {
            public int delivered { get; set; }
        }
        public class Stat
        {
            public Metrics metrics { get; set; }
        }
        public class RootObject
        {
            public List<Stat> stats { get; set; }
        }
..
            List<RootObject> o = JsonConvert.DeserializeObject<List<RootObject>>(json);
            var result = o.Sum(x => x.stats.Sum(y => y.metrics.delivered));
