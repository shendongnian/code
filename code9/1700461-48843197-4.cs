    class CustomHashSetEqualityComparer<T> : IEqualityComparer<HashSet<T>>
    {
        private IEqualityComparer<T> m_comparer;
        public CustomHashSetEqualityComparer()
        {
            m_comparer = EqualityComparer<T>.Default;
        }
        public CustomHashSetEqualityComparer(IEqualityComparer<T> comparer)
        {
            if (comparer == null)
            {
                m_comparer = EqualityComparer<T>.Default;
            }
            else
            {
                m_comparer = comparer;
            }
        }
        // using m_comparer to keep equals properties in tact; don't want to choose one of the comparers
        public bool Equals(HashSet<T> x, HashSet<T> y)
        {
            // http://referencesource.microsoft.com/#System.Core/System/Collections/Generic/HashSet.cs,1360
            // handle null cases first
            if (x == null)
            {
                return (y == null);
            }
            else if (y == null)
            {
                // set1 != null
                return false;
            }
            // all comparers are the same; this is faster
            if (AreEqualityComparersEqual(x, y))
            {
                if (x.Count != y.Count)
                {
                    return false;
                }
            }
            // n^2 search because items are hashed according to their respective ECs
            foreach (T set2Item in y)
            {
                bool found = false;
                foreach (T set1Item in x)
                {
                    if (m_comparer.Equals(set2Item, set1Item))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    return false;
                }
            }
            return true;
        }
        public int GetHashCode(HashSet<T> obj)
        {
            int hashCode = 0;
            if (obj != null)
            {
                foreach (T t in obj)
                {
                    hashCode = hashCode ^ (m_comparer.GetHashCode(t) & 0x7FFFFFFF);
                }
            } // else returns hashcode of 0 for null hashsets
            return hashCode;
        }
        // Equals method for the comparer itself. 
        public override bool Equals(Object obj)
        {
            CustomHashSetEqualityComparer<T> comparer = obj as CustomHashSetEqualityComparer<T>;
            if (comparer == null)
            {
                return false;
            }
            return (this.m_comparer == comparer.m_comparer);
        }
        public override int GetHashCode()
        {
            return m_comparer.GetHashCode();
        }
        static private bool AreEqualityComparersEqual(HashSet<T> set1, HashSet<T> set2)
        {
            return set1.Comparer.Equals(set2.Comparer);
        }
    }
