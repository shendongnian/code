        private NullValueLastComparer() { }
        // two properties: the key selector and the comparer
        private Func<TClass, TKey> KeySelector { get; set; }
        private IComparer<TKey> KeyComparer { get; set; }
        // the actual compare function, that will get the values
        // according to the key selector 
        // and compares them such that a null value will be last
        public int Compare(TClass x, TClass y)
        {   
            if (Object.ReferenceEquals(x, null))
                throw new ArgumentNullException(nameof(x));
            if (Object.ReferenceEquals(y, null)
                throw new ArgumentNullException(nameof(y));
            // get the values to compare
			TKey keyX = KeySelector(x);
			TKey keyY = KeySelector(y);
			return this.Compare(keyX, keyY);
		}
        // the private function that compares the Keys
        // such that null values will be last
        private int Compare(TKey x, TKey y)
        {   // compare such that null values last, or if both not null, use IComparable
            if (Object.ReferenceEquals(x, null))
            {
                if (Object.ReferenceEquals(y, null))
                {   // both null
                    return 0;
                }
                else
                {   // x null, y not null => x follows y
                    return +1;
                }
            }
            else
            {   // x not null
                if (Object.ReferenceEquals(y, null))
                {   // x not null; y null: x precedes y
                    return -1;
                }
                else
                {
                    return this.KeyComparer.Compare(x, y);
                }
            }
        }
    }
