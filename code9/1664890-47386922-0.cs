    public static class Whatever
    {
        internal class Penguin
        {
            private Guid id;
            public Penguin()
            {
                id = Guid.NewGuid();
            }
            public Guid GetId() { return id; }
        }
        public static void Main(string[] args)
        {
            Penguin emperor = new Penguin(),
                adelie = new Penguin(),
                batmanVillain = new Penguin();
            var okay = new List<KeyValuePair<Penguin, int>>();
            okay.Add(new KeyValuePair<Penguin, int>(emperor, 1));
            okay.Add(new KeyValuePair<Penguin, int>(adelie, 2));
            okay.Add(new KeyValuePair<Penguin, int>(batmanVillain, 3));
            okay.Add(new KeyValuePair<Penguin, int>(emperor, -500));
            okay.Add(new KeyValuePair<Penguin, int>(batmanVillain, 5));
            okay.Sort((a, b) => a.Key.GetId().CompareTo(b.Key.GetId()));
            // Iterate 'okay'
        }
    }
 
