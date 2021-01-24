    class ItemSet
    {
        public List<ItemSet> ItemSets { get; set; }
        public bool hasSets { get; set; }
        public void Loop()
        {
            if (hasSets)
            {
                ItemSets.ForEach(s => s.Loop());
            }
            // do stuff here
        }
    } 
