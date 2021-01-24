    class Crate : IEnumerable<Beverage>
    {
        private Beverage[] crate = new Beverage[24];
        private int NumberOfBottles = 0;
        private const int MaxItems = 24;
    
        public void Add(Beverage beverage)
        {
            if (NumberOfBottles >= MaxItems)
            {
                Console.WriteLine("The crate is full. Please remove an item first!");
            }
            else
            {
                crate[NumberOfBottles] = beverage;
                NumberOfBottles++;
            }
        }
    
        public IEnumerator<Beverage> GetEnumerator()
        {
            return crate.AsEnumerable().GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
        public void Remove(string name)
        {
            Remove(crate.FirstOrDefault(i =>
                i.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
        }
    
        public void Remove(Beverage beverage)
        {
            int index = Array.IndexOf(crate, beverage, 0, NumberOfBottles);
            if (index < 0)
                return;
            this.RemoveAt(index);
        }
    
        /// <summary>
        /// Removes the element at the specified index of the Beverage array.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public void RemoveAt(int index)
        {
            if (index < NumberOfBottles)
            {
                NumberOfBottles--;
                Array.Copy(crate, index + 1, crate, index, NumberOfBottles - index);
                crate[NumberOfBottles] = default(Beverage);
            }
        }
    
        public void PrintCrate()
        {
            if (NumberOfBottles == 0)
            {
                Console.WriteLine("There are no items in the crate.");
            }
            else
            {
                foreach (var beverage in this)
                    Console.WriteLine(beverage);
            }
        }
    }
