    class Crate : List<Beverage>
    {
        public new void Add(Beverage beverage)
        {
            if (Count == 24)
            {
                Console.WriteLine("The crate is full. Please remove an item first!");
            }
            else
            {
                base.Add(beverage);
            }
        }
    
        public void Remove(string name)
        {
            Remove(this.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
        }
    
        public void PrintCrate()
        {
            if (this.Count == 0)
            {
                Console.WriteLine("There are no items in the crate.");
            }
            else
            {
                this.ForEach(Console.WriteLine);
            }
        }
    }
