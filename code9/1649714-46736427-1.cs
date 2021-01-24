            WeightedItem<string> alice = new WeightedItem<string>("alice", 1);
            WeightedItem<string> bob = new WeightedItem<string>("bob", 1);
            WeightedItem<string> charlie = new WeightedItem<string>("charlie", 1);
            WeightedItem<string> diana = new WeightedItem<string>("diana", 4);
            WeightedItem<string> elaine = new WeightedItem<string>("elaine", 1);
            List<WeightedItem<string>> myList = new List<WeightedItem<string>> { alice, bob, charlie, diana, elaine };
            string chosen = WeightedItem<string>.Choose(myList);
