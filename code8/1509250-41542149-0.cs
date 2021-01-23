        /// <summary>
        /// Checks if this hashset contains the item
        /// </summary>
        /// <param name="item">item to check for containment</param>
        /// <returns>true if item contained; false if not</returns>
        public bool Contains(T item) {
            if (m_buckets != null) {
                int hashCode = InternalGetHashCode(item);
                // see note at "HashSet" level describing why "- 1" appears in for loop
                for (int i = m_buckets[hashCode % m_buckets.Length] - 1; i >= 0; i = m_slots[i].next) {
                    if (m_slots[i].hashCode == hashCode && m_comparer.Equals(m_slots[i].value, item)) {
                        return true;
                    }
                }
            }
            // either m_buckets is null or wasn't found
            return false;
        }
