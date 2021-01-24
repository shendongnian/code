    class Range<T> where T : IComparable<T>
    {
        public T LBound { get; set; }
        public T UBound { get; set; }
        public bool ContainsValue(T value)
        {
            return (this.LBound.CompareTo(value) <= 0) && (value.CompareTo(this.UBound) <= 0);
        }
    }
        
    class RangeKeyComparer : IComparer<Range<double>>
    {
        public int Compare(Range<double> x, Range<double> y)
        {
            return x.UBound.CompareTo(y.UBound);
        }
    }
    class RangeAvlTree<T, TValue> : AvlTree<Range<T>, TValue> where T : IComparable<T>
    {
            
        public RangeAvlTree(IComparer<Range<T>> comparer)
        {
            //update access modifier to 'protected' in base class
            _comparer = comparer;
        }
        public bool Search(T searchKey, out TValue value)
        {
            //update access modifier to 'protected' in base class
            AvlNode<Range<T>, TValue> node = _root;
            while (node != null)
            {
                if (node.Key.ContainsValue(searchKey))
                {
                    value = node.Value;
                    return true;
                }
                else if (searchKey.CompareTo(node.Key.UBound) == 1)
                    node = node.Right;
                else if (searchKey.CompareTo(node.Key.UBound) == -1)
                    node = node.Left;
            }
            value = default(TValue);
            return false;
        }
    }
