        public List<string> FindKeys(string value, Hashtable hashTable)
        {
            var keyList = new List<string>();
            IDictionaryEnumerator e = hashTable.GetEnumerator();
            while (e.MoveNext())
            {
                if (e.Value.ToString().Equals(value))
                {
                    keyList.Add(e.Key.ToString());
                }
            }
            return keyList;
        }
