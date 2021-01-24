    class Product: IComparable
    {
        public int ID { get; set; }
        public uint Qty { get; set; }
        public int CompareTo(object obj)
        {
            if (obj is Product)
                return this.ID.CompareTo(((Product)obj).ID);
            else
                return -1;
        }
        public override string ToString()
        {
            return string.Format("Product: {0}", this.ID);
        }
    }
    class Combination : List<Product>, IComparable
    {
        public int Goal { get; private set; }
        public bool IsCompleted
        {
            get
            {
                return this.Sum(product => product.Qty) >= Goal;
            }
        }
        public Combination(int goal)
        {
            Goal = goal;
        }
        public Combination(int goal, params Product[] firstProducts)
            : this(goal)
        {
            AddRange(firstProducts);
        }
        public Combination(Combination inheritFrom)
            : base(inheritFrom)
        {
            Goal = inheritFrom.Goal;
        }
        public Combination(Combination inheritFrom, Product firstProduct)
            : this(inheritFrom)
        {
            Add(firstProduct);
        }
        public int CompareTo(object obj)
        {
            if (obj is Combination)
            {
                var destCombination = (Combination)obj;
                var checkIndex = 0;
                while (true)
                {
                    if (destCombination.Count - 1 < checkIndex && this.Count - 1 < checkIndex)
                        return 0;
                    else if (destCombination.Count - 1 < checkIndex)
                        return -1;
                    else if (this.Count - 1 < checkIndex)
                        return 1;
                    else
                    {
                        var result = this[checkIndex].CompareTo(destCombination[checkIndex]);
                        if (result == 0)
                            checkIndex++;
                        else
                            return result;
                    }
                }
            }
            else
                return this.CompareTo(obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return this.Select((item, idx) => item.ID * (10 ^ idx)).Sum();
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is Combination)
                return ((Combination)obj).GetHashCode() == this.GetHashCode();
            else
                return base.Equals(obj);
        }
    }
