        void Merge (Dictionary<string, int> a, Dictionary<string, int> b)
        {
            foreach (string key in a.Keys)
            {
                if (b.ContainsKey(key))
                {
                    b[key] = b[key] + a[key];
                }
                else
                {
                    b.Add(key, a[key]);
                }
            }
        }
