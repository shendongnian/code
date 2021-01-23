       private void Increment(string key)
        {
           var result =  ccd.AddOrUpdate(key,new KeyValuePair<object, int>(new object(), 1),(k, pair) => new KeyValuePair<object, int>(pair.Key, pair.Value + 1));
           RemoveEmptyNode(key, result);
        }
        private void Decrement(string key)
        {
            var result = ccd.AddOrUpdate(key, new KeyValuePair<object, int>(new object(), -1), (k, pair) => new KeyValuePair<object, int>(pair.Key, pair.Value - 1));
            RemoveEmptyNode(key, result);
        }
        private void RemoveEmptyNode(string key, KeyValuePair<object, int> result)
        {
            if (result.Value == 0)
            {
                KeyValuePair<object, int> removedKeyValuePair;
                if (ccd.TryRemove(key, out removedKeyValuePair))
                {
                    if (removedKeyValuePair.Value != 0)
                    {
                        ccd.AddOrUpdate(key, removedKeyValuePair,
                            (k, pair) => new KeyValuePair<object, int>(key, pair.Value + removedKeyValuePair.Value));
                    }
                }
            }
        }
    }
