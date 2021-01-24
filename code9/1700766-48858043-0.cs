    class CustomEqualityComparer<T> : IEqualityComparer<ICollection<T>>
    {
        public bool Equals(ICollection<T> x, ICollection<T> y)
        {
            if (x.Count != y.Count) return false;
            var enumerables = new Dictionary<T, uint>(x.Count);
    
            foreach (T item in x)
            {
                enumerables.TryGetValue(item, out var value);
                enumerables[item] = value + 1;
            }
    
            foreach (T item in y)
            {
                var success = enumerables.TryGetValue(item, out var value);
                if (success)
                {
                    enumerables[item] = value - 1;
                }
                else
                {
                    return false;
                }
            }
    
            return enumerables.Values.All(v => v == 0);
        }
    
        public int GetHashCode(ICollection<T> obj)
        {
             unchecked
             {
                 var hashCode = 0;
      
                 foreach(var item in obj)
                 {
                     hashCode += (item != null ? item.GetHashCode() : 0);                
                 }
                 return hashCode;
             }
      
         }
    }
